using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Comments.Commonds
{
    public class DeleteCommentCommond : IRequest
    {
        public int Id { get; set; }
        public class DeleteCommentHander : IRequestHandler<DeleteCommentCommond>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            public DeleteCommentHander(ICisEngDbContext cisEngDbContext)
            {
                _cisEngDbContext = cisEngDbContext;
            }
            public async Task<Unit> Handle(DeleteCommentCommond request, CancellationToken cancellationToken)
            {
                var entity = await _cisEngDbContext.Comments.FindAsync(request.Id);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Comment), request.Id);
                }
                _cisEngDbContext.Comments.Remove(entity);
                await _cisEngDbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
