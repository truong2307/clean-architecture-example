using MediatR;
using QuizApp.Application.Common.Models;

namespace QuizApp.Application.Users.Commands
{
    public class RegisterUserCommand : IRequest<BaseCommandResponse>
    {
        public string Email { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        public RegisterUserCommand(string email, string userName, string password)
        {
            Email = email;
            UserName = userName;
            Password = password;
        }
    }
}
