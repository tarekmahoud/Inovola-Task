using MediatR;

namespace Inovola.Application.Features.Auth.Commands.RegisterUser;

public class RegisterUserCommand:IRequest<string>
{

    public string UserName {  get; set; }
    public string Password { get; set; }    
    public string Email {  get; set; }
    public string Mobile {  get; set; }
}
