using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        [InverseProperty("Photos")]
        public User User { get; set; }
        [InverseProperty("UserFavorites")]
        public List<User> PhotoFavorites { get; set; }

        [InverseProperty("UserLikes")]
        public List<User> PhotoLikes { get; set; }
        [InverseProperty("Photo")]
        public List<Comment> PhotoComments { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public bool IsPrivate { get; set; }
    }
}
