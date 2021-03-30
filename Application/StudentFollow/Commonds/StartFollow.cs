using Application.Common.Interfaces;
using Application.Notifications.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.StudentProfile.Command
{
    public class StartFollow:INotification
    {
        public MessageDto Message { get; set; }
        public class StartFollowHandler : INotificationHandler<StartFollow>
        {
            private readonly INotifierMediatorService _notifierMediatorService;

            public StartFollowHandler(INotifierMediatorService notifierMediatorService)
            {
                _notifierMediatorService = notifierMediatorService;
            }
            public async Task Handle(StartFollow notification, CancellationToken cancellationToken)
            {
                await _notifierMediatorService.SendAsync(notification.Message);
            }
        }
    }
}
