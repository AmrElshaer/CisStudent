using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ResponseToComment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CommentId { get; set; }
        public Comment Comment { get; set; }
        public int? CisStudentId { get; set; }
        public CisStudent CisStudent { get; set; }
     
    }
}
