using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ResponsToComment.Commonds
{
    public class DeleteRespontCommentCommond : IRequest
    {
        public int Id { get; set; }
        public class DeleteRespontCommentHander : IRequestHandler<DeleteRespontCommentCommond>
        {
            private readonly ICisEngDbContext _cisEngDbContext;
            public DeleteRespontCommentHander(ICisEngDbContext cisEngDbContext)
            {
                _cisEngDbContext = cisEngDbContext;
            }
            public async Task<Unit> Handle(DeleteRespontCommentCommond request, CancellationToken cancellationToken)
            {
                var entity = await _cisEngDbContext.ResponseToComments.FindAsync(request.Id);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Comment), request.Id);
                }
                _cisEngDbContext.ResponseToComments.Remove(entity);
                await _cisEngDbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
