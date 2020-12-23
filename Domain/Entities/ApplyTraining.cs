using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ApplyTraining
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int? TrainingId { get; set; }
        public Training Training { get; set; }
        public int? CisStudentId { get; set; }
        public CisStudent CisStudent { get; set; }
        
    }
}
