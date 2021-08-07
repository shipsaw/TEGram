using Capstone.ApiResponseObjects;
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
        // GET: api/<UserController>
        [HttpGet]
        [Route("/api/user")]
        public IEnumerable<string> Get()
        {
            return _context.Users.Select(u => u.FirstName).ToList();
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
