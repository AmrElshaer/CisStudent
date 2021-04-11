using Application.Common.Interfaces;
using Application.Notifications.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Account.Commands.Register
{
   
    public class UserRegistered : INotification
    {
        public MessageDto Message { get; set; }
        public class UserRegisteredHandler : INotificationHandler<UserRegistered>
        {
            private readonly INotifierMediatorService _notifierMediatorService;

            public UserRegisteredHandler(INotifierMediatorService notifierMediatorService)
            {
                _notifierMediatorService = notifierMediatorService;
            }
            public async Task Handle(UserRegistered notification, CancellationToken cancellationToken)
            {
                await _notifierMediatorService.SendAsync(notification.Message);
            }
        }
    }
}
