using Capstone.DataTransferObjects;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capstone.Controllers
{
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/api/user/{id}")]
        public UserDto GetUserById(int id)
        {
            return _context.Users.AsNoTracking()
                .Include(u => u.Photos)
                .FirstOrDefault(u => u.UserId == id).MapUserToDto();
        }

        [HttpGet]
        [Route("/api/user")]
        public UserDto GetMyUserInfo()
        {
            int userId = GetUserIdFromJwt();
            return _context.Users.AsNoTracking()
                .Include(u => u.Photos)
                .FirstOrDefault(u => u.UserId == userId).MapUserToDto();
        }

        [HttpPost]
        [Route("/api/user/{id}/profile")]
        public ActionResult UpdateProfilePic([FromBody] string value, int id)
        {
            //return value;
            _context.Users.FirstOrDefault(u => u.UserId == id).ProfileUrl = value;
            _context.SaveChanges();
            return Ok();
        }
        // GET api/<UserController>/:id
        //[HttpGet("{id}")]
        //public ActionResult<UserDataResponse> Get(int id)
        //{
        //    return null;
        //}

        //// POST api/<UserController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<UserController>/5
        //[HttpPut]
        //[Route("api/user/{id}/profile")]
        //public void Put(int id, [FromBody] string value)
        //{

        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        private int GetUserIdFromJwt()
        {
            string userIdStr = HttpContext.User?.FindFirstValue("sub")?.ToString() ?? "-1";
            return int.Parse(userIdStr);
        }

    }
}
