using FluentValidation;
using QuizApp.Application.Users.Commands;

namespace QuizApp.Application.Users.Validations
{
    public class AuthenticateUserCommandValidator : AbstractValidator<AuthenticateUserCommand>
    {
        public AuthenticateUserCommandValidator()
        {
            RuleFor(v => v.AccountName).NotEmpty()
                .MaximumLength(256)
                .WithMessage("AccountName must not exceed 256 characters.");

            RuleFor(v => v.Password).NotEmpty()
                .MaximumLength(256)
                .Matches(@"(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&`])[A-Za-z\d$@$!%*?&].{4,}")
                .WithMessage("Password requires special characters, uppercase letters and numbers");
        }
    }
}
