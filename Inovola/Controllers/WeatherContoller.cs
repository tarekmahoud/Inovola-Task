using Inovola.Application.Features.City.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inovola.Presentation.Controllers;

[Authorize]
[Route("api/v1/[controller]")]
[ApiController]
public class WeatherContoller : ApiControllerBase
{
    public WeatherContoller()
    {   
        
    }

    [HttpGet(nameof(GetWeather))]
    public async Task<ActionResult<int?>> GetWeather([FromQuery] CityQuery query)
     => Ok(await Mediator.Send(query));
}
