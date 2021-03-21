using Application.Account;
using Application.Common.Mappings;
using System;
using Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using Application.StudentPost.Queries;

namespace Application.Comments
{
     public class CommentDto:IMapFrom
    {
        public CommentDto()
        {
            Comments = new List<CommentDto>();
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int? PostId { get; set; }
        public int? CisStudentId { get; set; }
        public CisStudentDto CisStudent { get; set; }
        public IList<CommentDto> Comments { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Comment, CommentDto>();
        }
    }
}
