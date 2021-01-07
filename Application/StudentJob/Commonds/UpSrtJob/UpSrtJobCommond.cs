using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.StudentJob.Commonds.UpSrtJob
{
    public class UpSrtJobCommond:IRequest<int>
    {

        public int? Id { get; set; }
        public string Technology { get; set; }
        public string Place { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }
        public string ContactUs { get; set; }
        public int CisStudentId { get; set; }
    }
}
