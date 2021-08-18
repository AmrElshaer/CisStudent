using Application.Common.Behaviour;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Application.StudentJob.Queries
{
    public class GetJobQuery : IRequest<JobDto>
    {
        public int Id { get; set; }
        public class GetJobQueryHandler : IRequestHandler<GetJobQuery, JobDto>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            private readonly IMapper _mapper;

            public GetJobQueryHandler(ICisEngDbContext cisEngDbContext, IMapper mapper)
            {
                _cisEngDbContext = cisEngDbContext;
                _mapper = mapper;
            }
            public async Task<JobDto> Handle(GetJobQuery request, CancellationToken cancellationToken)
            {
                var entity = await _cisEngDbContext.Jobs.FindAsync(request.Id);
                Guard.Against.Null(entity, request.Id);
                var postDto = _mapper.Map<JobDto>(entity);
                return postDto;
            }
        }
    }
}
