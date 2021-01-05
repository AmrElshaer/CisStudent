using Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Account.Commands.Login
{
    public class LoginCommandValidator:AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator(IUserManager userManager)
        {
            RuleFor(d => d.Email).NotEmpty();
            RuleFor(d => d.Password).NotEmpty();
            RuleFor(d => d).Custom((d, context) => {
                if (!string.IsNullOrEmpty(d.Password)&&!string.IsNullOrEmpty(d.Email))
                {
                     var isRegister =  userManager.UserIsRegister(d.Email,d.Password).GetAwaiter().GetResult();
                     if (!isRegister)
                             context.AddFailure("","Email or Password are Incorrect");
                }
               
            });
        }
    }
}
