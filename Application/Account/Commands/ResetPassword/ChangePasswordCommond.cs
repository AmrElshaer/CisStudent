using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Account.Commands.ResetPassword
{
    public class ChangePasswordCommond:IRequest<Result>
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }

        public class ChangePasswordCommondHandler : IRequestHandler<ChangePasswordCommond, Result>
        {
            private readonly IUserManager _userServiceManager;

            public ChangePasswordCommondHandler(IUserManager userManager)
            {
                _userServiceManager = userManager;
            }

            public async Task<Result> Handle(ChangePasswordCommond request, CancellationToken cancellationToken)
            {
                var result=  await _userServiceManager.ChangePassword(request.Email, request.Token,request.NewPassword);
                return result;
            }
        }
    }
}
