using Inovola.Application.Interfaces;
using Inovola.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Inovola.Application.Features.Auth.Queries.Login
{
    public class LoginHandler : IRequestHandler<LoginQuery, string>
    {
        public IMemoryCache _cacheService;
        public IJWTService _jwtService;
        public LoginHandler(IMemoryCache cacheService, IJWTService jwtService)
        {
            _cacheService = cacheService;
            _jwtService = jwtService;
        }
        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            string errorMessage = "userName or Password Wrong";

            if (!_cacheService.TryGetValue(request.UserName, out User cachedValue))
                return errorMessage;
            else
            {
                if (request.Password != cachedValue.Password)
                    return errorMessage;
                else
                    return _jwtService.GenerateJwtToken(request.UserName);
                
            }

        }
    }
}
