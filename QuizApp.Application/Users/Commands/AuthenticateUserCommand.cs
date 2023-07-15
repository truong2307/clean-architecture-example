using MediatR;
using QuizApp.Application.Common.Models;
using System.Runtime.Serialization;

namespace QuizApp.Application.Users.Commands
{
    public class AuthenticateUserCommand : IRequest<Response<string>>
    {
        [DataMember]
        public string AccountName { get; private set; }

        [DataMember]
        public string Password { get; private set; }

        public AuthenticateUserCommand(string accountName, string password)
        {
            AccountName = accountName;
            Password = password;
        }
    }
}
