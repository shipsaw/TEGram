using System.Collections.Generic;

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

