using Capstone.ApiResponseObjects;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
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
        private readonly PackagingHelper packagingHelper;
        public PhotoController(ApplicationDbContext context)
        {
            _context = context;
            packagingHelper = new PackagingHelper(context);
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Route("/api/photo")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet]
        [Route("/api/photo/{id}")]
        public ActionResult<PhotoDataResponse> Get(int id)
        {
            return packagingHelper.PackagePhoto(id);
        }

        // GET api/feed
        [AllowAnonymous]
        [HttpGet]
        [Route("/api/photo/feed")]
        //[Route("/")]
        public ActionResult<List<PhotoDataResponse>> GetFeed()
        {
            return packagingHelper.PackagePhotos(p => p.UserId > 0);
        }

        [HttpGet]
        [Route("/api/photo/favorites")]
        //[Route("/")]
        public ActionResult<List<PhotoDataResponse>> GetFavorites()
        {
            string userIdStr = HttpContext.User?.FindFirstValue("sub")?.ToString() ?? "-1";
            int userId = int.Parse(userIdStr);

            return packagingHelper.PackagePhotos(p => p.PhotoFavorites.Any(u => u.UserId == userId));
        }

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<ValuesController>/5
        //[HttpPut("like/{id}")]
        [HttpPut] // Pass the fact we want to change like in the query string
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

        //TODO Feed route /api/photo/feed
        // /api/feed

        // DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        private bool ToggleLike(int photoId)
        {
            string userIdStr = HttpContext.User?.FindFirstValue("sub")?.ToString() ?? "-1";
            int userId = int.Parse(userIdStr);

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
            string userIdStr = HttpContext.User?.FindFirstValue("sub")?.ToString() ?? "-1";
            int userId = int.Parse(userIdStr);

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

    }
}
