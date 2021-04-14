using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Account.Commands.ResetPassword
{
    public class ResetPasswordCommond : IRequest<Unit>
    {
        public string Email { get; set; }
        public string ClientURI { get; set; }

        public class ResetPasswordCommondHandler : IRequestHandler<ResetPasswordCommond, Unit>
        {
            private readonly IUserManager _userServiceManager;

            public ResetPasswordCommondHandler(IUserManager userManager, IMediator mediator)
            {
                _userServiceManager = userManager;
            }

            public async Task<Unit> Handle(ResetPasswordCommond request, CancellationToken cancellationToken)
            {
                await _userServiceManager.ForgetPassword(request.Email, request.ClientURI);
                return Unit.Value;
            }
        }
    }
}