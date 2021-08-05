using Capstone.ApiResponseObjects;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public string Put(int id/*, [FromBody] int userId*/)
        {
            string username = HttpContext.User?.FindFirstValue("name")?.ToString() ?? "Not Found";
            string userIdStr = HttpContext.User?.FindFirstValue("sub")?.ToString() ?? "-1";
            int userId = int.Parse(userIdStr);

            var photo = _context.Photos.Include(p => p.PhotoLikes).FirstOrDefault(p => p.PhotoId == id);


            if (photo.PhotoLikes.FirstOrDefault(p => p.UserId == userId) != null)
            {
                photo.PhotoLikes.Remove(_context.Users.Find(userId));
                _context.SaveChanges();
                return $"Like Found, removing entry, userId: {userId}, photoId: {id}";
            }
            else
            {
                photo.PhotoLikes.Add(_context.Users.Find(userId));
                _context.SaveChanges();
                return $"No Like Found, adding entry, userId: {userId}, photoId: {id}";
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
