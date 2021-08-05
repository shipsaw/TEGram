using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    public class UserInfoResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserProfileUrl { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<PhotoDataResponse> Photos {get; set;} = new List<PhotoDataResponse>();
    }
}
