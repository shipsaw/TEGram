using System;
using System.Collections.Generic;
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
        public ICollection<User> PhotoLikes { get; set; }
        [InverseProperty("Photo")]
        public ICollection<Comment> PhotoComments { get; set; }
    }
}
