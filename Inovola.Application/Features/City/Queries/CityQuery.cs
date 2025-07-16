using MediatR;

namespace Inovola.Application.Features.City.Queries;

public record CityQuery(string cityName):IRequest<int?>;
