using Application.Account;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.StudentMessage
{
    public class ChatMessageDto:IMapFrom
    {
        public int Id { get; set; }
        public int? SendId { get; set; }
        public CisStudentDto SendSTD { get; set; }
        public int? RecieveId { get; set; }
        public CisStudentDto RecieveSTD { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsSee { get; set; }
        public string Content { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Message, ChatMessageDto>().ReverseMap();
        }
    }
}
