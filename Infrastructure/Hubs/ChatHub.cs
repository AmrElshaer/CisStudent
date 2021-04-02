using Application.Common.Interfaces;
using Application.StudentMessage;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Hubs
{
    public class ChatHub:Hub, IChatHup
    {
        private static ConcurrentDictionary<string, string> _connections = new ConcurrentDictionary<string, string>();
        private readonly IHubContext<ChatHub> _hubContext;
        public ChatHub(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }
        //Add User To Group when is connection
        public  void JoinToGroup(string name)
        {
          var value=  _connections.AddOrUpdate(name,Context.ConnectionId,(x,y)=> Context.ConnectionId);
        }
        // remove user form group
        public void RemoveFromGroup(string name)
        {
            _connections.TryRemove(name,out string value);
        }
        (bool isActive,string ConnectionId) IChatHup.IsActive(string name)
        {
            return (_connections.TryGetValue(name,out string value),value);
        }
    }
   
}
