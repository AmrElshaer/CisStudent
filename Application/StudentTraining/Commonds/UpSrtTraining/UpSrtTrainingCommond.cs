using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.StudentTraining.Commonds.UpSrtTraining
{
    public class UpSrtTrainingCommond:IRequest<int>
    {

        public int? Id { get; set; }
        public string Technology { get; set; }
        public string Place { get; set; }
        public string CreateDate { get; set; }
        public string Content { get; set; }
        public string ContactUs { get; set; }
        public int CisStudentId { get; set; }
    }
}
