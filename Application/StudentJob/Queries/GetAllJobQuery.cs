using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Application.StudentJob.Queries
{
    public class GetAllJobQuery:IRequest<IList<JobDto>>
    {
        public int StudentId { get; set; }
        public class GetAllJobQueryHandler : IRequestHandler<GetAllJobQuery, IList<JobDto>>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            private readonly IMapper _mapper;

            public GetAllJobQueryHandler(ICisEngDbContext cisEngDbContext,IMapper mapper)
            {
                _cisEngDbContext = cisEngDbContext;
                _mapper = mapper;
            }
            public async Task<IList<JobDto>> Handle(GetAllJobQuery request, CancellationToken cancellationToken)
            {
                var trainings = await _cisEngDbContext.Jobs.Include(p => p.CisStudent)
                    .Where(p => p.CisStudentId == request.StudentId).OrderByDescending(p=>p.Id).ProjectTo<JobDto>(_mapper.ConfigurationProvider).ToListAsync();
                return trainings;
            }
        }
    }
}
