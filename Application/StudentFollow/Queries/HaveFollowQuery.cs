using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Application.StudentFollow.Queries
{
    public class HaveFollowQuery:IRequest<FollowDto>
    {
        public int SendId { get; set; }
        public int ReceiveId { get; set; }
        public class HaveFollowQueryHandler : IRequestHandler<HaveFollowQuery, FollowDto>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            private readonly IMapper _mapper;

            public HaveFollowQueryHandler(ICisEngDbContext cisEngDbContext, IMapper mapper)
            {
                _cisEngDbContext = cisEngDbContext;
                _mapper = mapper;
            }
            public async Task<FollowDto> Handle(HaveFollowQuery request, CancellationToken cancellationToken)
            {
                var entity = await _cisEngDbContext.Follows.FirstOrDefaultAsync(f=>f.CisStudentSendId==request.SendId&&f.CisStudentRecieveId==request.ReceiveId);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(FollowDto), request.SendId);
                }
                var entityDto= this._mapper.Map<FollowDto>(entity);
                return entityDto;
            }
        }
    }
}
