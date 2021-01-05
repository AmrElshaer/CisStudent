using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Account.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, (string token, string image)>
    {
        private readonly IJwtFactoryService _jwtFactoryService;
        private readonly ICisEngDbContext _cisEngDbContext;
        public LoginCommandHandler(IJwtFactoryService jwtFactoryService,ICisEngDbContext cisEngDbContext)
        {
            _jwtFactoryService = jwtFactoryService;
            _cisEngDbContext = cisEngDbContext;
        }
        public async Task<(string token,string image)> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user =await _cisEngDbContext.CisStudents.FirstOrDefaultAsync(s=>s.Email==request.Email);
            var token= await _jwtFactoryService.GenerateEncodedToken(user.Name,user.Id);
            return (token,user.Image);
        }
    }
}
