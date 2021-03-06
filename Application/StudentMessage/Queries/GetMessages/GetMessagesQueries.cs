﻿using Application.Common.Interfaces;
using Application.StudentMessage.Commonds;
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
            private readonly IMediator mediator;

            public GetMessagesQueriesHandler(ICisEngDbContext context, IMapper mapper,IMediator mediator)
            {
                this.context = context;
                this.mapper = mapper;
                this.mediator = mediator;
            }

            public async Task<IList<ChatMessageDto>> Handle(GetMessagesQueries request, CancellationToken cancellationToken)
            {
                var messages =await this.context.Messages.Include(a=>a.SendSTD).Include(a=>a.RecieveSTD)
                    .Where(a=>(a.RecieveId==request.RecieveSTDId||a.RecieveId==request.SendSTDId)
                &&(a.SendId==request.SendSTDId||a.SendId==request.RecieveSTDId))
                    .OrderBy(a=>a.CreateDate).ProjectTo<ChatMessageDto>(this.mapper.ConfigurationProvider).ToListAsync();
                // make messages as see
               await  mediator.Send(new UpdateMessageToSeeCommond() { Between=(request.SendSTDId,request.RecieveSTDId)});
                return messages;
            }
        }
    }
}
