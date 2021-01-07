using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Application.StudentTraining.Queries
{
    public class GetAllTrainingQuery:IRequest<IList<TrainingDto>>
    {
        public int StudentId { get; set; }
        public class GetAllTrainingQueryHandler : IRequestHandler<GetAllTrainingQuery, IList<TrainingDto>>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            private readonly IMapper _mapper;

            public GetAllTrainingQueryHandler(ICisEngDbContext cisEngDbContext,IMapper mapper)
            {
                _cisEngDbContext = cisEngDbContext;
                _mapper = mapper;
            }
            public async Task<IList<TrainingDto>> Handle(GetAllTrainingQuery request, CancellationToken cancellationToken)
            {
                var trainings = await _cisEngDbContext.Trainings.Include(p => p.CisStudent)
                    .Where(p => p.CisStudentId == request.StudentId).OrderByDescending(p=>p.Id).ProjectTo<TrainingDto>(_mapper.ConfigurationProvider).ToListAsync();
                return trainings;
            }
        }
    }
}
