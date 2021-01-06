using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Application.StudentPost.Queries
{
    public class GetAllPostQuery:IRequest<IList<PostDto>>
    {
        public int StudentId { get; set; }
        public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQuery, IList<PostDto>>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            private readonly IMapper _mapper;

            public GetAllPostQueryHandler(ICisEngDbContext cisEngDbContext,IMapper mapper)
            {
                _cisEngDbContext = cisEngDbContext;
                _mapper = mapper;
            }
            public async Task<IList<PostDto>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
            {
                var posts = await _cisEngDbContext.Posts.Include(p => p.CisStudent)
                    .Where(p => p.CisStudentId == request.StudentId).OrderByDescending(p=>p.Id).ProjectTo<PostDto>(_mapper.ConfigurationProvider).ToListAsync();
                return posts;
            }
        }
    }
}
