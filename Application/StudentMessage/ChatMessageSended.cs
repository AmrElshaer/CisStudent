using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentMessage
{
    public  class ChatMessageSended:INotification
    {
        public Message  ChatMessage { get; set; }
        public string ConnectionString { get; set; }
        public class ChatMessageSendedHandler : INotificationHandler<ChatMessageSended>
        {
            public readonly ICisEngDbContext context;
            public readonly IChatService chatService;
            private readonly IMapper mapper;
            public ChatMessageSendedHandler(ICisEngDbContext context, IChatService chatService, IMapper mapper)
            {
                this.context = context;
                this.chatService = chatService;
                this.mapper = mapper;
            }
            public async Task Handle(ChatMessageSended notification, CancellationToken cancellationToken)
            {
                var sendUser = await this.context.CisStudents.FindAsync(notification.ChatMessage.SendId);
                var recUser = await this.context.CisStudents.FindAsync(notification.ChatMessage.RecieveId);
                notification.ChatMessage.SendSTD = sendUser;
                notification.ChatMessage.RecieveSTD = recUser;
                var chatMessageDto = this.mapper.Map<ChatMessageDto>(notification.ChatMessage);
                await this.chatService.SendMessageAsync(chatMessageDto,notification.ConnectionString);
            }
        }
    }
}
