using FluentValidation;

namespace Inovola.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserValidator: AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {

            RuleFor(_ => _.UserName)
            .NotEmpty()
            .WithMessage("يجب إدخال الأسم");

            RuleFor(_ => _.Password)
           .NotEmpty()
           .WithMessage("يجب إدخال الرقم السرى");

            RuleFor(_ => _.Email)
            .NotEmpty()
            .WithMessage("يجب إدخال البريد الألكترونى")
            .EmailAddress()
            .WithMessage("يجب ادخال بريد الكترونى صحيح");

        }
    }
}
