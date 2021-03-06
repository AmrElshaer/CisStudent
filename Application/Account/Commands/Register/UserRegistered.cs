﻿using Application.Common.Interfaces;
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
        public string ConfirmLink;
        public string Email;

        public UserRegistered(string confirmLink, string email)
        {
            ConfirmLink = confirmLink ?? throw new ArgumentNullException(nameof(confirmLink));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        public class UserRegisteredHandler : INotificationHandler<UserRegistered>
        {
            private readonly INotifierMediatorService _notifierMediatorService;

            public UserRegisteredHandler(INotifierMediatorService notifierMediatorService)
            {
                _notifierMediatorService = notifierMediatorService;
            }
            public async Task Handle(UserRegistered notification, CancellationToken cancellationToken)
            {
                var message = new MessageDto()
                {
                    Body = $"<h1>Click Here to Confirm Account to CisEng</h1> <a href='{notification.ConfirmLink}'>Confirm Account</a>",
                    To = notification.Email,
                    Subject = $"Please Confirm your Account"
                };
                await _notifierMediatorService.SendAsync(message);
            }
        }
    }
}
