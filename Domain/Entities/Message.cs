using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int? SendId { get; set; }
        public CisStudent SendSTD { get; set; }
        public int? RecieveId { get; set; }
        public CisStudent RecieveSTD { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsSee { get; set; }
        public string Content { get; set; }
    }
}
