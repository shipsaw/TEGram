using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.ApiResponseObjects

{
    public class PhotoDataResponse
    {
        public int PhotoId { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public List<CommentDataResponse> Comments { get; set; } = new List<CommentDataResponse>();
        public List<int> Likes { get; set; } = new List<int>();
        public List<int> Favorites { get; set; } = new List<int>();
    }

    public class CommentDataResponse
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
    }
}

