using MediatR;
using QuizApp.Application.Common.Interfaces;
using QuizApp.Application.Common.Models;

namespace QuizApp.Application.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, BaseCommandResponse>
    {
        private readonly IIdentityService _identityService;

        public RegisterUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<BaseCommandResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var rs = new BaseCommandResponse()
            {
                Success = await _identityService.RegisterUserAsync(request.Email, request.UserName, request.Password)
            };
            return rs;
        }
    }
}
