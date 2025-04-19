using Application.Commands.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Auth
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator(ILocalizer localizer)
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(localizer.GetString("UsernameRequired"))
                .MaximumLength(50).WithMessage(localizer.GetString("UsernameTooLong"));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(localizer.GetString("PasswordRequired"))
                .MinimumLength(6).WithMessage(localizer.GetString("PasswordTooShort"));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(localizer.GetString("EmailRequired"))
                .EmailAddress().WithMessage(localizer.GetString("InvalidEmail"))
                .MaximumLength(100).WithMessage(localizer.GetString("EmailTooLong"));

            RuleFor(x => x.Phone)
                .MaximumLength(20).WithMessage(localizer.GetString("PhoneTooLong"))
                .Matches(@"^\+?[1-9]\d{1,14}$").When(x => !string.IsNullOrEmpty(x.Phone))
                .WithMessage(localizer.GetString("InvalidPhone"));

            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage(localizer.GetString("RoleRequired"));
        }
    }
}
