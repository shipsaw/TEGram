using Capstone.DataTransferObjects;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capstone.Controllers
{
    [ApiController]
    [Authorize]
    public class PhotoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PhotoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get photo by specific photo ID
        //GET api/photo/{id}
        [HttpGet]
        [Route("/api/photo/{id}")]
        public ActionResult<PhotoDto> Get(int id)
        {
            return _context.Photos.AsNoTracking().FirstOrDefault(p => p.PhotoId == id).MapPhotoToDto();
        }

        // Get the universal photo feed
        // GET api/feed
        [AllowAnonymous]
        [HttpGet]
        [Route("/api/photo/feed")]
        public ActionResult<List<PhotoDto>> GetFeed()
        {
            return _context.Photos
                .AsNoTracking()
                .Include(p => p.PhotoComments)
                .ThenInclude(c => c.User)
                .Include(p => p.PhotoLikes)
                .Include(p => p.PhotoFavorites)
                .OrderByDescending(p => p.CreatedDate)
                .MapPhotoQueryToDto().ToList();
        }

        // Get the user's favorites
        // Get /api/photo/favorites
        [HttpGet]
        [Route("/api/photo/favorites")]
        public ActionResult<List<PhotoDto>> GetFavorites()
        {
            int userId = GetUserIdFromJwt();

            return _context.Photos
                .AsNoTracking()
                .Include(p => p.PhotoFavorites)
                .Where(p => p.PhotoFavorites.Any(u => u.UserId == userId))
                .MapPhotoQueryToDto()
                .ToList();
        }

        // Post new photos to the database
        // POST /api/photo
        [HttpPost]
        [Route("/api/photo")]
        public ActionResult PostPhoto([FromBody] string photoUrl)
        {
            int userId = GetUserIdFromJwt();

                Photo newPhoto = new Photo
                {
                    UserId = userId,
                    Url = photoUrl
                };

                _context.Photos.Add(newPhoto);
                _context.SaveChanges();

            return Ok();
        }

        // Post a comment to the provided photo
        // POST api/photo/{id}/comment
        [HttpPost]
        [Route("/api/photo/{id}/comment")]
        public ActionResult PostComment([FromBody] string value, int id)
        {
            int userId = GetUserIdFromJwt();

            var comment = new Comment { UserId = userId, PhotoId = id, Content = value };
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return Ok();
        }

        // Put request to update photo likes / favorites
        // Pass the fact we want to change like in the query string
        // PUT /api/photo/{id}
        [HttpPut] 
        [Route("/api/photo/{id}")]
        public bool Put(int id, string action)
        {
            switch (action)
            {
                case "like":
                    return ToggleLike(id);
                case "favorite":
                    return ToggleFavorite(id);
                default:
                    break;
            }
            return false;
        }

        // Delete the provided photo if it belongs to the user
        // DELETE api/<UserController>/5
        [HttpDelete]
        [Route("/api/photo/{id}")]
        public ActionResult Delete(int id)
        {
            int requestingUserId = GetUserIdFromJwt();
            Photo photo = _context.Photos.Include(p => p.UserId).FirstOrDefault(u => u.PhotoId == id);
            if (photo != null && requestingUserId == photo.UserId)
            {
                photo.IsDeleted = true;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        private bool ToggleLike(int photoId)
        {
            int userId = GetUserIdFromJwt();

            var photo = _context.Photos.Include(p => p.PhotoLikes).FirstOrDefault(p => p.PhotoId == photoId);

            if (photo.PhotoLikes.FirstOrDefault(p => p.UserId == userId) != null)
            {
                photo.PhotoLikes.Remove(_context.Users.Find(userId));
                _context.SaveChanges();
                return false;
            }
            else
            {
                photo.PhotoLikes.Add(_context.Users.Find(userId));
                _context.SaveChanges();
                return true;
            }
        }
        private bool ToggleFavorite(int photoId)
        {
            int userId = GetUserIdFromJwt();
            var photo = _context.Photos.Include(p => p.PhotoFavorites).FirstOrDefault(p => p.PhotoId == photoId);

            if (photo.PhotoFavorites.FirstOrDefault(p => p.UserId == userId) != null)
            {
                photo.PhotoFavorites.Remove(_context.Users.Find(userId));
                _context.SaveChanges();
                return false;
            }
            else
            {
                photo.PhotoFavorites.Add(_context.Users.Find(userId));
                _context.SaveChanges();
                return true;
            }
        }
        private int GetUserIdFromJwt()
        {
        string userIdStr = HttpContext.User?.FindFirstValue("sub")?.ToString() ?? "-1";
            return int.Parse(userIdStr);
        }
    }
}
