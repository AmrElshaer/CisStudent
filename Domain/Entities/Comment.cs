using System;
using System.Collections.Generic;
namespace Domain.Entities
{
    public class Comment
    {
        public Comment()
        {
            ResponseToComments = new HashSet<ResponseToComment>();
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int? PostId { get; set; }
        public Post Post { get; set; }
        public int? CisStudentId { get; set; }
        public CisStudent CisStudent { get; set; }
        public ICollection<ResponseToComment> ResponseToComments { get; set; }

    }
}
