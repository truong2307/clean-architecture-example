using FluentValidation;
using QuizApp.Application.Users.Commands;

namespace QuizApp.Application.Users.Validations
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(v => v.Email).NotEmpty()
                .EmailAddress()
                .WithMessage("Try again with a valid email address.");

            RuleFor(v => v.UserName).NotEmpty()
                .MaximumLength(256)
                .WithMessage("User Name must not exceed 256 characters.");

            RuleFor(v => v.Password).NotEmpty()
                .MaximumLength(256)
                .Matches(@"(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&`])[A-Za-z\d$@$!%*?&].{4,}")
                .WithMessage("Password requires special characters, uppercase letters and numbers.");
        }
    }
}
