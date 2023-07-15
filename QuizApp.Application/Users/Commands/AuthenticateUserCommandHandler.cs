using MediatR;
using QuizApp.Application.Common.Interfaces;
using QuizApp.Application.Common.Models;

namespace QuizApp.Application.Users.Commands
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, Response<string>>
    {
        private readonly IIdentityService _identityService;
        public AuthenticateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Response<string>> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var rs = new Response<string>
            {
                IsSuccess = await _identityService.ValidateUser(request.AccountName, request.Password)
            };
            if (!rs.IsSuccess) return rs;

            rs.Result = await _identityService.CreateToken();
            return rs;
        }
    }
}
