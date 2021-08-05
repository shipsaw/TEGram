using Capstone.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("AllowSpecificOrigin")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _context.Users.Select(u => u.FirstName).ToList();
        }

        // GET api/<UserController>/:id
        [HttpGet("{id}")]
        public ActionResult<UserInfoResponse> Get(int id)
        {
            return null;
        }

        // GET api/<UserController>/:id
        [HttpGet("feed")]
        public ActionResult<List<PhotoDataResponse>> GetFeed(int id)
        {
            return PackagePhotos(p => p.UserId > 0);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private List<PhotoDataResponse> PackagePhotos(Expression<Func<Photo, bool>> predicate)
        {
            List<Photo> photos = _context.Photos.Where(predicate).OrderByDescending(p => p.CreatedDate).ToList();
            List<PhotoDataResponse> retPhotos = new List<PhotoDataResponse>();
            foreach (var photo in photos)
            {
                retPhotos.Add(new PhotoDataResponse
                {
                    Url = photo.Url,
                    UserId = photo.UserId,
                    Comments = null,
                    Likes = null
                });

            }
            return retPhotos;
        }

    }
}
