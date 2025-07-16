using FluentAssertions;
using Inovola.Application.Features.City.Queries;
using Inovola.Application.Interfaces;
using Inovola.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Inovola.Test
{
    public class CityTest
    {
        private readonly IMediator _mediator;

        public CityTest()
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddScoped<ICityService, MockedCityService>();
            services.AddMemoryCache();
            services.AddMediatR(cfg =>cfg.RegisterServicesFromAssemblyContaining<CityHandler>());

            var provider = services.BuildServiceProvider();
            _mediator = provider.GetRequiredService<IMediator>();
        }
        [Fact]
        public async Task TestCity1()
        {
            var result = await _mediator.Send(new CityQuery("cairo"));
            result.Should().NotBeNull();
            result.Should().Be(33);

        }
        [Fact]
        public async Task TestCity12()
        {
            var result = await _mediator.Send(new CityQuery("ca"));
            result.Should().BeNull();

        }
    }
}