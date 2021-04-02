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

namespace Application.StudentMessage.Queries.GetMessages
{
    public  class GetMessagesQueries:IRequest<IList<ChatMessageDto>>
    {
        public int SendSTDId { get; set; }
        public int RecieveSTDId { get; set; }
        public class GetMessagesQueriesHandler : IRequestHandler<GetMessagesQueries, IList<ChatMessageDto>>
        {
            private readonly ICisEngDbContext context;
            private readonly IMapper mapper;

            public GetMessagesQueriesHandler(ICisEngDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<IList<ChatMessageDto>> Handle(GetMessagesQueries request, CancellationToken cancellationToken)
            {
                var messages =await this.context.Messages.Include(a=>a.SendSTD).Include(a=>a.RecieveSTD)
                    .Where(a=>(a.RecieveId==request.RecieveSTDId||a.RecieveId==request.SendSTDId)
                &&(a.SendId==request.SendSTDId||a.SendId==request.RecieveSTDId))
                    .OrderBy(a=>a.CreateDate).ProjectTo<ChatMessageDto>(this.mapper.ConfigurationProvider).ToListAsync();
                return messages;
            }
        }
    }
}
