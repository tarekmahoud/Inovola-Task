using Inovola.Application.Interfaces;
using Inovola.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Inovola.Infrastructure.Services;

public class MockedCityService : ICityService
{
    public IMemoryCache _cacheService;
    public List<City> CityList;
    public MockedCityService(IMemoryCache cacheService)
    {
        _cacheService = cacheService;
        CityList = new List<City>
        {
            new City { Weather = 33, Name = "Cairo" },
            new City { Weather = 25, Name = "Alexandria" },
            new City { Weather = 40, Name = "Aswan" }
        };
    }
    public async Task<City?> GetWeatherByCityName(string cityName)
    {

        var cachedData = _cacheService.TryGetValue(cityName, out City result);

        if (result == null)
        {

            result = CityList.FirstOrDefault(m => m.Name.ToLower() == cityName.ToLower());
            
            if (result != null)
                CachData(result);
            else
                return default;
        }

        return result;
    }
    private void CachData(City city)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
        };

        _cacheService.Set(city.Name, city, cacheEntryOptions);

    }


}
