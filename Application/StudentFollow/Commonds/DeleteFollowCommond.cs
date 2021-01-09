using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentFollow.Commonds
{
    public class DeleteFollowCommond:IRequest
    {
        public int Id { get; set; }
        public class DeleteFollowCommondHandler : IRequestHandler<DeleteFollowCommond>
        {
            private readonly ICisEngDbContext _cisEngDbContext;

            public DeleteFollowCommondHandler(ICisEngDbContext cisEngDbContext)
            {
                _cisEngDbContext = cisEngDbContext;
            }
            public async Task<Unit> Handle(DeleteFollowCommond request, CancellationToken cancellationToken)
            {
                var entity = await _cisEngDbContext.Follows.FindAsync(request.Id);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Follow), request.Id);
                }
                _cisEngDbContext.Follows.Remove(entity);
                await _cisEngDbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
