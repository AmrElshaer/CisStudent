using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Account.Commands.Register
{
    public class RegisterCommand:IRequest<Result>
    {
        public string Name { get; set; }
        public  string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string ClientUrl { get; set; }
    }
}
