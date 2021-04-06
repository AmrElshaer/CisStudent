using Application.Common.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentMessage.Commonds
{
    /// <summary>
    /// Make message see
    /// </summary>
    public class UpdateMessageToSeeCommond : IRequest<Unit>
    {
        public (int? Sender,int Reciver)  Between { get; set; }
        public class UpdateMessageCommondHandler : IRequestHandler<UpdateMessageToSeeCommond, Unit>
        {
            public readonly ICisEngDbContext context;

            public UpdateMessageCommondHandler(ICisEngDbContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(UpdateMessageToSeeCommond request, CancellationToken cancellationToken)
            {
                context.Messages.Where(a => (request.Between.Sender==null|| a.SendId == request.Between.Sender) && a.RecieveId == request.Between.Reciver &&
                a.IsSee == false).ToList().ForEach(a => a.IsSee = true);
                await context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}