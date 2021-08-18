using Application.Common.Behaviour;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentLikes.Commonds
{
    public class RemoveReactionCommond:IRequest
    {
        public int PostId { get; set; }
        public int StudentId { get; set; }
        public class RemoveReactionHanlder : IRequestHandler<RemoveReactionCommond>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            public RemoveReactionHanlder(ICisEngDbContext cisEngDbContext)
            {
                _cisEngDbContext = cisEngDbContext;

            }
            public async Task<Unit> Handle(RemoveReactionCommond request, CancellationToken cancellationToken)
            {
                var like = await _cisEngDbContext.Likes.FirstOrDefaultAsync(a => a.PostId == request.PostId && a.StudentId == request.StudentId);
                Guard.Against.Null(like, request.PostId);
                _cisEngDbContext.Likes.Remove(like);
                await _cisEngDbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
