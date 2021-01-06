using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentPost.Commonds.DeletePost
{
    public class DeletePostCommondHandler : IRequestHandler<DeletePostCommond>
    {
        private readonly ICisEngDbContext _cisEngDbContext;

        public DeletePostCommondHandler(ICisEngDbContext cisEngDbContext)
        {
            _cisEngDbContext = cisEngDbContext;
        }
        public async Task<Unit> Handle(DeletePostCommond request, CancellationToken cancellationToken)
        {
            var entity =await _cisEngDbContext.Posts.FindAsync(request.Id);
            if (entity==null)
            {
                throw new NotFoundException(nameof(Post),request.Id);
            }
            _cisEngDbContext.Posts.Remove(entity);
            await _cisEngDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
