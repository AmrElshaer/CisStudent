using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Follow
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsAccepte { get; set; }
        public int? CisStudentSendId { get; set; }
        public CisStudent CisStudentSend { get; set; }
        public int? CisStudentRecieveId { get; set; }
        public CisStudent CisStudentRecieve { get; set; }
        
    }
}
