using Application.Commands.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Auth
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator(ILocalizer localizer)
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(localizer.GetString("UsernameRequired"))
                .MaximumLength(50).WithMessage(localizer.GetString("UsernameTooLong"));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(localizer.GetString("PasswordRequired"))
                .MinimumLength(6).WithMessage(localizer.GetString("PasswordTooShort"));
        }
    }
}
