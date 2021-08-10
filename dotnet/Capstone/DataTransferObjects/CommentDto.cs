using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DataTransferObjects
{
    public class CommentDto
    {
            public int CommentId { get; set; }
            public string Content { get; set; }
            public string Username { get; set; }
    }
}
