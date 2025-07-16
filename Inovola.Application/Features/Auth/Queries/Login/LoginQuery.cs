using MediatR;

namespace Inovola.Application.Features.Auth.Queries.Login
{
    public class LoginQuery:IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
