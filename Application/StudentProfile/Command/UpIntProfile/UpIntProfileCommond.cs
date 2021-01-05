using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.StudentProfile.Command.UpIntProfile
{
    public  class UpIntProfileCommond:IRequest<int>
    {
        public int? Id { get; set; }
        public string City { get; set; }
        public string Colleage { get; set; }
        public string University { get; set; }
        public string Age { get; set; }
        public string Experience { get; set; }
        public string Language { get; set; }
        public string Programing_Language { get; set; }
        public string Carear { get; set; }
        public string Appreciation { get; set; }
        public string Company { get; set; }
        public string Addition { get; set; }
        public string kind { get; set; }
        public int CisStudentId { get; set; }
    }
}
