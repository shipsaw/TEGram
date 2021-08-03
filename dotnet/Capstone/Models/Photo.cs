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
        public DateTime UploadTime { get; set; }
        [InverseProperty("Photos")]
        public User User { get; set; }
        [InverseProperty("FavPhotos")]
        public virtual List<User> UsersFavorited { get; set; }
        public List<Comment> Comments { get; set; }
        [InverseProperty("Likes")]
        public List<User> Likes { get; set; }
    }
}
