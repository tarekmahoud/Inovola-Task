using Inovola.Domain.Entities;
namespace Inovola.Application.Interfaces;

public interface  ICityService
{
   Task<City?> GetWeatherByCityName(string cityName);
}
