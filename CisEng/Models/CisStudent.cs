using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CisEng.Models
{
    public class CisStudent
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentImage { get; set; }
        public string StudentLevel { get; set; }
        public string password { get; set; }
    }
}
