using Application.Common.Interfaces;
using FluentValidation;
namespace Application.Account.Commands.Register
{
    public  class RegisterCommandValidator:AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator(IUserManager userManager)
        {
            RuleFor(r => r.Name).MinimumLength(8).MaximumLength(60).NotEmpty().Must(userManager.IsUniqueName).WithMessage("This Name is already exist");
            RuleFor(r => r.Email).EmailAddress().NotEmpty().Must(userManager.IsUniqueEmail).WithMessage("This Email is already exist");
            RuleFor(r => r.Password).MinimumLength(6).NotEmpty();
        }
        
        

    }
}
