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

namespace Application.Comments.Queries
{
    public class GetComments:IRequest<IList<CommentDto>>
    {
        public int CommentId { get; set; }
        public class GetCommentsHandler : IRequestHandler<GetComments, IList<CommentDto>>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            private readonly IMapper _mapper;

            public GetCommentsHandler(ICisEngDbContext cisEngDbContext, IMapper mapper)
            {
                _cisEngDbContext = cisEngDbContext;
                _mapper = mapper;
            }
            public async Task<IList<CommentDto>> Handle(GetComments request, CancellationToken cancellationToken)
            {
                var comments =await _cisEngDbContext.Comments.Include(a=>a.CisStudent).Include(a=>a.Comments)
                    .Where(a=>a.CommentId==request.CommentId).ProjectTo<CommentDto>(_mapper.ConfigurationProvider).ToListAsync();
                return comments;
            }
        }
    }
}
