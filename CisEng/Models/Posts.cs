using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CisEng.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public string Title { get; set; }
     
        public string Technology { get; set; }
        public string Postcontaint  { get; set; }
        public string CisStudentId { get; set; }
        public string PostPrivte { get; set; }
        public DateTime dateTime { get; set; }
    }
}
