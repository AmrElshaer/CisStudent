using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.StudentPost.Commonds.UpSrtPost
{
    public class UpSrtPostCommond:IRequest<int>
    {
        
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int CisStudentId { get; set; }
    }
}
