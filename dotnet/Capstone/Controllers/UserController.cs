using Capstone.ApiResponseObjects;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capstone.Controllers
{
    [ApiController]
    //[EnableCors("AllowSpecificOrigin")]
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
            int userId = GetUserFromJwt();
            return packagingHelper.PackageUser(userId, p => p.User.UserId == userId);
        }

        private int GetUserFromJwt()
        {
            throw new NotImplementedException();
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

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    }
}
