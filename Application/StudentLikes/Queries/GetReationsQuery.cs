using Application.Common.Interfaces;
using Application.StudentPost.Queries;
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

namespace Application.StudentLikes.Queries
{
    public class GetReationsQuery:IRequest<IList<LikeDto>>
    {
        public int PostId { get; set; }
        public class GetReactionsHanlder : IRequestHandler<GetReationsQuery, IList<LikeDto>>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            private readonly IMapper _mapper;

            public GetReactionsHanlder(ICisEngDbContext cisEngDbContext, IMapper mapper)
            {
                _cisEngDbContext = cisEngDbContext;
                _mapper = mapper;
            }
            public async Task<IList<LikeDto>> Handle(GetReationsQuery request, CancellationToken cancellationToken)
            {
               return await _cisEngDbContext.Likes.Where(a => a.PostId == request.PostId).ProjectTo<LikeDto>(_mapper.ConfigurationProvider).ToListAsync();
            }
        }
    }
}
