﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Technology { get; set; }
        public string Content { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime CreateDate { get; set; }
        public int CisStudentId { get; set; }
        public CisStudent CisStudent { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
