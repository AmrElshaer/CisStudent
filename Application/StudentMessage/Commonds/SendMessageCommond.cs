using Application.Account;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentMessage.Commonds
{
    public class SendMessageCommond:IRequest<int>
    {
        public ChatMessageDto MessageDto { get; set; }
        public class SendMessageCommondHandler : IRequestHandler<SendMessageCommond, int>
        {
            public readonly ICisEngDbContext context;
            private readonly IMediator mediator;
            private readonly IChatHup chatHup;
            private readonly IMapper mapper;

            public SendMessageCommondHandler(ICisEngDbContext context,IMediator mediator,IChatHup chatHup,IMapper mapper)
            {
                this.context = context;
                this.mediator = mediator;
                this.chatHup = chatHup;
                this.mapper = mapper;
            }
            public async Task<int> Handle(SendMessageCommond request, CancellationToken cancellationToken)
            {
                 var message = this.mapper.Map<Message>(request.MessageDto);
                 var recieved =  this.context.CisStudents.Find(message.RecieveId);
                var checkActivation = this.chatHup.IsActive(recieved.Name);
                 message.IsSee = checkActivation.isActive;
                 await  this.context.Messages.AddAsync(message);
                 await  this.context.SaveChangesAsync(cancellationToken);
                if (checkActivation.isActive)
                {
                    await this.mediator.Publish(new ChatMessageSended() { ChatMessage=message,
                     ConnectionString=checkActivation.ConnectionId});
                }

                return message.Id;
            }
        }
    }
}
