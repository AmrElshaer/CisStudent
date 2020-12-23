using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public  class ApplyJob
    {
        public int Id { get; set; }
        public int? JobId { get; set; }
        public Job Job { get; set; }
        public int? CisStudentId { get; set; }
        public CisStudent  CisStudent { get; set; }
        public string Content { get; set; }
    }
}
