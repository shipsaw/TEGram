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
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
    }
}
