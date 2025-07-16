using Inovola.Application.Features.Auth.Commands.RegisterUser;
using Inovola.Application.Features.Auth.Queries.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inovola.Presentation.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController : ApiControllerBase
{

    [HttpPost(nameof(RegisterNewUser))]
    public async Task<ActionResult<string>> RegisterNewUser([FromBody] RegisterUserCommand command)
        => Ok(await Mediator.Send(command));


    [HttpGet(nameof(Login))]
    public async Task<ActionResult<string>> Login([FromQuery] LoginQuery query)
        => Ok(await Mediator.Send(query));

}
