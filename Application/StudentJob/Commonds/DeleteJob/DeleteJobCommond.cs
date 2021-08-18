using Application.Common.Behaviour;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentJob.Commonds.DeleteJob
{
    public class DeleteJobCommond:IRequest
    {
        public int Id { get; set; }
        public class DeleteJobCommondHandler : IRequestHandler<DeleteJobCommond>
        {
            private readonly ICisEngDbContext _cisEngDbContext;

            public DeleteJobCommondHandler(ICisEngDbContext cisEngDbContext)
            {
                _cisEngDbContext = cisEngDbContext;
            }
            public async Task<Unit> Handle(DeleteJobCommond request, CancellationToken cancellationToken)
            {
                var entity = await _cisEngDbContext.Jobs.FindAsync(request.Id);
                Guard.Against.Null(entity, request.Id);
                _cisEngDbContext.Jobs.Remove(entity);
                await _cisEngDbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
