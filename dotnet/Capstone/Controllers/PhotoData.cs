using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    public class PhotoData
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public List<string> Comments { get; set; } = new List<string>();
        public List<string> Likes { get; set; } = new List<string>();
    }
}
