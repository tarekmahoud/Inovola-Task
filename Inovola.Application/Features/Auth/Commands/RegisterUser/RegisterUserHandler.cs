using Inovola.Application.Interfaces;
using Inovola.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Inovola.Application.Features.Auth.Commands.RegisterUser;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, string>
{
    public IMemoryCache _cacheService;
    public IJWTService _jwtService;

    public RegisterUserHandler( IJWTService jwtService,IMemoryCache cacheService)
    {
        _cacheService= cacheService;
        _jwtService= jwtService;

    }
    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {

        if (_cacheService.TryGetValue(request.UserName, out User cachedValue))
            return $"userName : {request.UserName} already found";
        
        SaveUser(request);

        return _jwtService.GenerateJwtToken(request.UserName);

    }
    private void SaveUser(RegisterUserCommand request)
    {
        var user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            Password = request.Password,
        };

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
        };

        _cacheService.Set(request.UserName, user, cacheEntryOptions);
    }
}
