using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Account.Commands.Login
{
    public  class LoginCommand:IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
