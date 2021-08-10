using Capstone.ApiResponseObjects;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly PackagingHelper packagingHelper;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
            packagingHelper = new PackagingHelper(context);
        }

        [HttpGet]
        [Route("/api/user/{id}")]
        public UserDataResponse GetUserById(int id)
        {
            return packagingHelper.PackageUser(id, p => p.User.UserId == id);
        }

        [HttpGet]
        [Route("/api/user")]
        public UserDataResponse GetMyUserInfo()
        {
            int userId = GetUserIdFromJwt();
            return packagingHelper.PackageUser(userId, p => p.User.UserId == userId);
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

        // DELETE api/<UserController>/5
        [HttpDelete]
        [Route("/api/user/{id}")]
        public ActionResult Delete(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                user.IsDeleted = true;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }
        private int GetUserIdFromJwt()
        {
            string userIdStr = HttpContext.User?.FindFirstValue("sub")?.ToString() ?? "-1";
            return int.Parse(userIdStr);
        }

    }
}
