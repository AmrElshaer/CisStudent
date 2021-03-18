using Application.Account;
using Application.Comments;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.StudentPost.Queries
{
    public class ResponseToCommentDto : IMapFrom
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CommentId { get; set; }
        public int? CisStudentId { get; set; }
        public CisStudentDto CisStudent { get; set; }
        public void Mapping(AutoMapper.Profile profile)
        {
                profile.CreateMap<ResponseToComment, ResponseToCommentDto>();
        }
    }
}
