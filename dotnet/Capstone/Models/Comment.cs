using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [InverseProperty("PhotoComments")]
        public Photo Photo { get; set; }
        [InverseProperty("UserComments")]
        public User User { get; set; }
        public string Content { get; set; }
    }
}
