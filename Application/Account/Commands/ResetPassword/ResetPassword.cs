using Application.Common.Interfaces;
using Application.Notifications.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Account.Commands.ResetPassword
{
    public class ResetPassword : INotification
    {
        public string ConfirmLink;
        public string Email;

        public ResetPassword(string confirmLink, string email)
        {
            ConfirmLink = confirmLink ?? throw new ArgumentNullException(nameof(confirmLink));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        public class UserRegisteredHandler : INotificationHandler<ResetPassword>
        {
            private readonly INotifierMediatorService _notifierMediatorService;

            public UserRegisteredHandler(INotifierMediatorService notifierMediatorService)
            {
                _notifierMediatorService = notifierMediatorService;
            }
            public async Task Handle(ResetPassword notification, CancellationToken cancellationToken)
            {
                var message = new MessageDto()
                {
                    Body = $"<h1>Click Here to Confirm Change Password</h1> <a href='{notification.ConfirmLink}'>Confirm Account</a>",
                    To = notification.Email,
                    Subject = $"Change your password"
                };
                await _notifierMediatorService.SendAsync(message);
            }
        }
    }
}
