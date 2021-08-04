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
        private ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> users = _context.Users.Select(u => u.FirstName).ToList();
            return users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<PageData> Get(int id)
        {
            return PackageUser(id, p => p.User.UserId == id);
        }

        // GET api/<UserController>/5
        [HttpGet("feed")]
        public ActionResult<PageData> GetFeed(int id)
        {
            return PackageUser(id, p => p.User.UserId >= 0);
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

        private PageData PackageUser(int id, Expression<Func<Photo, bool>> predicate)
        {
            User user = _context.Users.First(u => u.UserId == id);
            PageData data = new PageData();
            data.UserProfileUrl = user.ProfileUrl;
            data.UserId = user.UserId;
            data.Username = user.Username;
            data.Firstname = user.FirstName;
            data.Lastname = user.LastName;

            List<Photo> photos = _context.Photos.Where(predicate).OrderByDescending(p => p.CreatedDate).ToList();
            foreach (var photo in photos)
            {
                data.Photos.Add(new PhotoData
                {
                    Url = photo.Url,
                    UserId = photo.UserId,
                    Comments = null,
                    Likes = null
                });

            }
            return data;
        }
    }
}
