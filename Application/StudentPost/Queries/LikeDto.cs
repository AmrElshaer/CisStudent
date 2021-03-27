using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
namespace Application.StudentPost.Queries
{
    public class LikeDto : IMapFrom
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public Account.CisStudentDto Student { get; set; }
        public int? PostId { get; set; }
        public int ReactionIndex { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Like, LikeDto>();
        }
    }
}
