using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Account.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand,string>
    {
        private readonly IJwtFactoryService _jwtFactoryService;

        public LoginCommandHandler(IJwtFactoryService jwtFactoryService)
        {
            _jwtFactoryService = jwtFactoryService;
        }
        public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return  _jwtFactoryService.GenerateEncodedToken(request.Email);
        }
    }
}
