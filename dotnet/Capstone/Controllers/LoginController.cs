using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using Capstone.Security;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Capstone.DataTransferObjects;

namespace Capstone.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenGenerator tokenGenerator;
        private readonly IPasswordHasher passwordHasher;
        private readonly ApplicationDbContext _context;

        public LoginController(ITokenGenerator _tokenGenerator, IPasswordHasher _passwordHasher, ApplicationDbContext context)
        {
            tokenGenerator = _tokenGenerator;
            passwordHasher = _passwordHasher;
            _context = context;
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Authenticate(LoginUser userParam)
        {
            // Default to bad username/password message
            IActionResult result = Unauthorized(new { message = "Username or password is incorrect" });

            // Get the user by username  -- ApplicationDbContext --> User objects --> list of attrbutes
            User user = _context.Users.FirstOrDefault(u => u.Username == userParam.Username);

            // If we found a user and the password hash matches
            if (user != null && passwordHasher.VerifyHashMatch(user.PasswordHash, userParam.Password, user.Salt))
            {
                // Create an authentication token
                string token = tokenGenerator.GenerateToken(user.UserId, user.Username, user.Role);
                user = ControllerHelper.AddDataToUser(_context, user.UserId);


                // Create a ReturnUser object to return to the client
                LoginResponse retUser = new LoginResponse() { User = user.MapUserToDto(), Token = token };

                // Switch to 200 OK
                result = Ok(retUser);
            }

            return result;
        }

        [HttpPost]
        [Route("/register")]
        public IActionResult Register(RegisterUser userParam)
        {
            IActionResult result;

            User existingUser = _context.Users.FirstOrDefault(u => u.Username == userParam.Username);

            if (existingUser != null)
            {
                return Conflict(new { message = "Username already taken. Please choose a different username." });
            }

            var passwordHash = passwordHasher.ComputeHash(userParam.Password);
            User user = new User
            {
                Username = userParam.Username,
                PasswordHash = passwordHash.Password,
                Salt = passwordHash.Salt,
                Role = userParam.Role,
                ProfileUrl = "https://tegramprofilephotobucket.s3.us-east-2.amazonaws.com/blankprofilephoto.png"
            };

            var retUser = _context.Users.Add(user);
            if (retUser != null)
            {
                result = Created(user.Username, null); //values aren't read on client
                _context.SaveChanges();
            }
            else
            {
                result = BadRequest(new { message = "An error occurred and user was not created." });
            }

            return result;
        }
    }
}
