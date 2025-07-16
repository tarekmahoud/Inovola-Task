using Inovola.Application.Interfaces;
using MediatR;

namespace Inovola.Application.Features.City.Queries;

public class CityHandler : IRequestHandler<CityQuery, int?>
{
    private readonly ICityService _cityWeatherService;
    public CityHandler(ICityService cityWeatherService)
    {
        _cityWeatherService = cityWeatherService;
    }
    public async Task<int?> Handle(CityQuery request, CancellationToken cancellationToken)
    {

        var result = await _cityWeatherService.GetWeatherByCityName(request.cityName);

        return result?.Weather;

    }
}
