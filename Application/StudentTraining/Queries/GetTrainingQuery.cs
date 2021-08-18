using Application.Common.Behaviour;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Application.StudentTraining.Queries
{
    public class GetTrainingQuery : IRequest<TrainingDto>
    {
        public int Id { get; set; }
        public class GetTrainingQueryHandler : IRequestHandler<GetTrainingQuery, TrainingDto>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            private readonly IMapper _mapper;

            public GetTrainingQueryHandler(ICisEngDbContext cisEngDbContext, IMapper mapper)
            {
                _cisEngDbContext = cisEngDbContext;
                _mapper = mapper;
            }
            public async Task<TrainingDto> Handle(GetTrainingQuery request, CancellationToken cancellationToken)
            {
                var entity = await _cisEngDbContext.Trainings.FindAsync(request.Id);
                Guard.Against.Null(entity, request.Id);
                var postDto = _mapper.Map<TrainingDto>(entity);
                return postDto;
            }
        }
    }
}
