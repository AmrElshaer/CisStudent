using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentFollow.Queries
{
    public class GetFollowers:IRequest<IEnumerable<FollowDto>>
    {
        public int StudentId { get; set; }
        public class GetFollowersQueryHandler : IRequestHandler<GetFollowers, IEnumerable<FollowDto>>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            private readonly IMapper _mapper;

            public GetFollowersQueryHandler(ICisEngDbContext cisEngDbContext, IMapper mapper)
            {
                _cisEngDbContext = cisEngDbContext;
                _mapper = mapper;
            }
            public async Task<IEnumerable<FollowDto>> Handle(GetFollowers request, CancellationToken cancellationToken)
            {
                var entities = await _cisEngDbContext.Follows.Include(a=>a.CisStudentSend).Include(a=>a.CisStudentRecieve).Where(f => f.CisStudentRecieveId == request.StudentId).ToListAsync();
               
                var entitiesDto = this._mapper.Map<IEnumerable<FollowDto>>(entities);
                return entitiesDto;
            }
        }
    }
}
