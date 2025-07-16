using FluentValidation;

namespace Inovola.Application.Features.Auth.Queries.Login;

public class LoginValidator : AbstractValidator<LoginQuery>
{
    public LoginValidator()
    {

        RuleFor(_ => _.UserName)
        .NotEmpty()
        .WithMessage("يجب إدخال الأسم");

        RuleFor(_ => _.Password)
       .NotEmpty()
       .WithMessage("يجب إدخال الرقم السرى");
    }
}
