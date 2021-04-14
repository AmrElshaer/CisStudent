using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Account.Commands.ResetPassword
{
    class ForgotPasswordValidators : AbstractValidator<ResetPasswordCommond>
    {
      
            public ForgotPasswordValidators()
            {
                RuleFor(r => r.Email).NotEmpty();
                RuleFor(r => r.ClientURI).NotEmpty();
            }



        
    }
}
