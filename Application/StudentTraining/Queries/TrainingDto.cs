using Application.Account;
using Application.Common.Mappings;
using Domain.Entities;
using System;
namespace Application.StudentTraining.Queries
{
    public class TrainingDto : IMapFrom
    {
        public int Id { get; set; }
        public string Technology { get; set; }
        public string Place { get; set; }
        public string CreateDate { get; set; }
        public string Content { get; set; }
        public string ContactUs { get; set; }
        public int CisStudentId { get; set; }
        public CisStudent CisStudent { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Training, TrainingDto>();
        }
    }
}
