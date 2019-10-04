using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CisEng.Models
{
    public class Comments
    {
        public int id { get; set; }
        public string comment { get; set; }
        public string StudentId { get; set; }
        public string PostId { get; set; }
        public DateTime Time { get; set; }

    }
}
