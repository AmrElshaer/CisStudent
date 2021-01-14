using Application.Account;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.StudentFollow.Queries
{
    public class FollowDto:IMapFrom
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsAccepte { get; set; }
        public int? CisStudentSendId { get; set; }
        public CisStudentDto CisStudentSend { get; set; }
        public int? CisStudentRecieveId { get; set; }
        public CisStudentDto CisStudentRecieve { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<Follow, FollowDto>();
        }
    }
}