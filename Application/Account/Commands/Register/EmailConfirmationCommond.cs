using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Account.Commands.Register
{
    public class EmailConfirmationCommond:IRequest<Unit>
    {
        public string Token { get; set; }
        public string  Email { get; set; }
        public class EmailConfirmationCommondHandler : IRequestHandler<EmailConfirmationCommond, Unit>
        {
            private readonly IUserManager _userManager;
            public EmailConfirmationCommondHandler(IUserManager userManager)
            {
                this._userManager = userManager;
            }
            public async Task<Unit> Handle(EmailConfirmationCommond request, CancellationToken cancellationToken)
            {
                 await _userManager.ConfirmationEmail(request.Email,request.Token);
                return Unit.Value;
            }
        }
    }
}
