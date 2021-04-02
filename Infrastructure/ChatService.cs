using Application.Account;
using Application.Common.Interfaces;
using Application.StudentMessage;
using Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ChatService : IChatService
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatService(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(ChatMessageDto message,string connectionId)
        {
            await _hubContext.Clients.Client(connectionId).SendAsync("ReciveMessage",message);
        }
        
    }
}
