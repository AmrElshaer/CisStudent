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
        private readonly IMediator _mediator;

        public RegisterCommandHandler(ICisEngDbContext cisEngDbContext,IUserManager userManager,IMediator mediator)
        {
            _cisEngDbContext = cisEngDbContext;
            _userServiceManager = userManager;
            this._mediator = mediator;
        }
        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result= await _userServiceManager.CreateUserAsync(request.Name,request.Password,request.Email,request.ClientUrl);
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
