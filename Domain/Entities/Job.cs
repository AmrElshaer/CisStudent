using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Job
    {
        public Job()
        {
            Applies = new HashSet<ApplyJob>();
        }
        public int Id { get; set; }
        public string Technology { get; set; }
        public string Place { get; set; }
        public DateTime CreateDate{ get; set; }
        public string Content { get; set; }
        public string ContactUs { get; set; }
        public int CisStudentId { get; set; }
        public CisStudent CisStudent { get; set; }
        public ICollection<ApplyJob> Applies { get; set; }
    }
}
