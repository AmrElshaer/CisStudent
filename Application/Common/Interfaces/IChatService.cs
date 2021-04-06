using Application.Account;
using Application.Notifications.Models;
using Application.StudentMessage;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Application.Common.Interfaces
{
    public interface IChatService
    {
        Task SendMessageAsync(ChatMessageDto message, string connectionId);
    }
}
