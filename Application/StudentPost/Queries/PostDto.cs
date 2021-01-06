using Application.Account;
using Application.Common.Mappings;
using Domain.Entities;
using System;
namespace Application.StudentPost.Queries
{
    public class PostDto : IMapFrom
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int CisStudentId { get; set; }
        public CisStudentDto CisStudent { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Post, PostDto>();
        }
    }
}
