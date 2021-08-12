using Capstone.DataTransferObjects;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            return ControllerHelper.AddDataToUser(_context, id).MapUserToDto();
        }

        [HttpGet]
        [Route("/api/user")]
        public List<PhotoDto> GetMyUserInfo()
        {
            int userId = GetUserIdFromJwt();
            return ControllerHelper.AddDataToUser(_context, userId).Photos.MapPhotoListToDto().ToList();
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
        private int GetUserIdFromJwt()
        {
            string userIdStr = HttpContext.User?.FindFirstValue("sub")?.ToString() ?? "-1";
            return int.Parse(userIdStr);
        }

    }
}
