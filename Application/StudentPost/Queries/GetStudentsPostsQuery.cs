using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentPost.Queries
{
    public class GetStudentsPostsQuery:IRequest<IList<PostDto>>
    {
        public class GetStudentsPostsQueryHandler : IRequestHandler<GetStudentsPostsQuery, IList<PostDto>>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            private readonly IMapper _mapper;

            public GetStudentsPostsQueryHandler(ICisEngDbContext cisEngDbContext, IMapper mapper)
            {
                _cisEngDbContext = cisEngDbContext;
                _mapper = mapper;
            }
            public async Task<IList<PostDto>> Handle(GetStudentsPostsQuery request, CancellationToken cancellationToken)
            {
                var posts = await _cisEngDbContext.Posts.Include(p => p.CisStudent).OrderByDescending(p => p.Id).ProjectTo<PostDto>(_mapper.ConfigurationProvider).ToListAsync();
                return posts;
            }
        }
    }
}
