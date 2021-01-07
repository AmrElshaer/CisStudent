using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentTraining.Commonds.DeleteTraining
{
    public class DeleteTrainingCommond:IRequest
    {
        public int Id { get; set; }
        public class DeleteTrainingCommondHandler : IRequestHandler<DeleteTrainingCommond>
        {
            private readonly ICisEngDbContext _cisEngDbContext;

            public DeleteTrainingCommondHandler(ICisEngDbContext cisEngDbContext)
            {
                _cisEngDbContext = cisEngDbContext;
            }
            public async Task<Unit> Handle(DeleteTrainingCommond request, CancellationToken cancellationToken)
            {
                var entity = await _cisEngDbContext.Trainings.FindAsync(request.Id);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Training), request.Id);
                }
                _cisEngDbContext.Trainings.Remove(entity);
                await _cisEngDbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
