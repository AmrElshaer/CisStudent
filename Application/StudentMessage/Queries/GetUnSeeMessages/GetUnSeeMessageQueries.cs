using Application.Common.Interfaces;
using Application.StudentMessage.Commonds;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentMessage.Queries.GetUnSeeMessages
{
    public class GetUnSeeMessageQueries : IRequest<IList<ChatMessageDto>>
    {
        public int UserId { get; set; }

        public class GetUnSeeMessageQueriesHandler : IRequestHandler<GetUnSeeMessageQueries, IList<ChatMessageDto>>
        {
            private readonly ICisEngDbContext context;
            private readonly IMapper mapper;
            private readonly IMediator mediator;

            public GetUnSeeMessageQueriesHandler(ICisEngDbContext context, IMapper mapper, IMediator mediator)
            {
                this.context = context;
                this.mapper = mapper;
                this.mediator = mediator;
            }

            public async Task<IList<ChatMessageDto>> Handle(GetUnSeeMessageQueries request, CancellationToken cancellationToken)
            {
                var misMessages = await this.context.Messages.Include(a => a.SendSTD).Include(a => a.RecieveSTD)
                .Where(a => a.RecieveId == request.UserId && a.IsSee == false).GroupBy(a => a.SendId)
                     .Select(a => a.Last()).ToListAsync();
                if (misMessages.Any())
                {
                    // make messages as see
                    await mediator.Send(new UpdateMessageToSeeCommond() { Between = (null, request.UserId) });
                }

                return this.mapper.Map<IList<ChatMessageDto>>(misMessages);
            }
        }
    }
}