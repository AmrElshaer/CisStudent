using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Account.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand,Result>
    {
        private readonly ICisEngDbContext _cisEngDbContext;
        private readonly IUserManager _userServiceManager;

        public RegisterCommandHandler(ICisEngDbContext cisEngDbContext,IUserManager userManager)
        {
            _cisEngDbContext = cisEngDbContext;
            _userServiceManager = userManager;
        }
        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
           var result= await _userServiceManager.CreateUserAsync(request.Name,request.Password,request.Email);
            if (result.Result.Succeeded)
            {
                var cisStudent = new CisStudent() { Name=request.Name,Email=request.Email,Image=request.Image};
                _cisEngDbContext.CisStudents.Add(cisStudent);
                await  _cisEngDbContext.SaveChangesAsync(cancellationToken);
            }
            return result.Result;
        }
    }
}
