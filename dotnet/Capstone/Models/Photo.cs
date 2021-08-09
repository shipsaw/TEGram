using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
