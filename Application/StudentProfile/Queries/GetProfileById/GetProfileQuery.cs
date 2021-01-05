using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.StudentProfile.Queries.GetProfileById
{
    public class GetProfileQuery:IRequest<ProfileDto>
    {
        public int StudentId { get; set; }
    }
}
