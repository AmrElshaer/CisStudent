using Application.Common.Interfaces;
using Application.Notifications.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MediatR;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class EmailNofifierService : INotifierMediatorService
    {
        private readonly IOptions<MailSettings> _mailSettings;

        public EmailNofifierService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings;
        }

        public async Task SendAsync(MessageDto message)
        {
            
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_mailSettings.Value.Mail);
                email.To.Add(MailboxAddress.Parse(message.To));
                email.Subject = message.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = message.Body;
                email.Body = builder.ToMessageBody();
                using (var smtp=new SmtpClient())
                {
                    smtp.Connect(_mailSettings.Value.Host, _mailSettings.Value.Port, SecureSocketOptions.StartTls);
                    smtp.Authenticate(_mailSettings.Value.Mail, _mailSettings.Value.Password);
                    await smtp.SendAsync(email);
                    smtp.Disconnect(true);
                }
           
            
        }
    }
}
