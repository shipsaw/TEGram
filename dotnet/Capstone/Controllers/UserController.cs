using Capstone.ApiResponseObjects;
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
        private readonly PackagingHelper packagingHelper;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
            packagingHelper = new PackagingHelper(context);
        }

        [HttpGet]
        [Route("/api/user/{id}")]
        public UserDto GetUserById(int id)
        {
            return _context.Users.AsNoTracking().MapUserToDto().FirstOrDefault(u => u.UserId == id);
        }

        [HttpGet]
        [Route("/api/user")]
        public UserDto GetMyUserInfo()
        {
            int userId = GetUserIdFromJwt();
            return _context.Users.AsNoTracking().MapUserToDto().FirstOrDefault(u => u.UserId == userId);
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
