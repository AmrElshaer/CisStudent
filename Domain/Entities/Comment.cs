using System;
using System.Collections.Generic;
namespace Domain.Entities
{
    public class Comment
    {
        public Comment()
        {
            Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int? PostId { get; set; }
        public Post Post { get; set; }
        public int? CisStudentId { get; set; }
        public CisStudent CisStudent { get; set; }
        public int? CommentId { get; set; }
        public Comment Comm { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
