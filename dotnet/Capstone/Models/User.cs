using Capstone.ApiResponseObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public string ProfileUrl { get; set; }
        [InverseProperty("User")]
        public List<Photo> Photos { get; set; }

        [InverseProperty("PhotoFavorites")]
        public List<Photo> UserFavorites { get; set; }

        [InverseProperty("PhotoLikes")]
        public List<Photo> UserLikes { get; set; }
        [InverseProperty("User")]
        public List<Comment> UserComments { get; set; }

        public string Role { get; set; }
    }

    /// <summary>
    /// Model to return upon successful login (user data + token)
    /// </summary>
    public class LoginResponse
    {
        public UserDataResponse User { get; set; }
        public string Token { get; set; }
    }

    /// <summary>
    /// Model to accept login parameters
    /// </summary>
    public class LoginUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// Model to accept registration parameters
    /// </summary>
    public class RegisterUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}
