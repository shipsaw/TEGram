using Capstone.DTO;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DataTransferObjects
  

{
    public class PhotoDto
    {
        public int PhotoId { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public List<CommentDto> Comments { get; set; } 
        public List<int> Likes { get; set; } 
        public List<int> Favorites { get; set; }
    }

}

