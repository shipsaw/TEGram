﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
    }
}