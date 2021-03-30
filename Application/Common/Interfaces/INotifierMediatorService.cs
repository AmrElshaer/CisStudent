using Application.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public  interface INotifierMediatorService
    {
        Task SendAsync(MessageDto message);
    }
}
