using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.StudentProfile.Queries.GetProfileById
{
    public class ProfileDto : IMapFrom
    {
        public int Id { get; set; }
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
        public CisStudent CisStudent { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Profile, ProfileDto>();
        }
    }
}
