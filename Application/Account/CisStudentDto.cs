using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Account
{
    public class CisStudentDto:IMapFrom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<CisStudent, CisStudentDto>();
        }
    }
}
