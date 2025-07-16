using FluentAssertions;
using Inovola.Application.Features.Auth.Commands.RegisterUser;
using Inovola.Application.Features.Auth.Queries.Login;
using Inovola.Application.Features.City.Queries;
using Inovola.Application.Interfaces;
using Inovola.Domain.Entities;
using Inovola.Infrastructure.Services;
using Inovola.Infrastructure.Settings;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inovola.Test
{
    public class UserTest
    {
        private readonly IMediator _mediator;

        public UserTest()
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddScoped<IJWTService, JWTService>();
            services.AddMemoryCache();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<RegisterUserHandler>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<LoginHandler>());

            var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                { "JwtSettings:SecretKey", "My-super-secret-key-1234567890-XYZ" },
                { "JwtSettings:Issuer", "Inovola" },
                { "JwtSettings:Audience", "Audience" },
                { "JwtSettings:ExpiryInMinutes", "60" }
            })
            .Build();


            services.Configure<JwtSettings>(config.GetSection("JwtSettings"));
            var provider = services.BuildServiceProvider();
            _mediator = provider.GetRequiredService<IMediator>();
        }
        [Fact]
        public async Task RegisterUser1()
        {

            var result1 = await RegisterUser();

            result1.Should().NotBeNull();
            result1.Should().NotBe($"userName : tarek already found");

        }
        [Fact]
        public async Task RegisterUser2()
        {

            var result1 = await RegisterUser();
            var result2 = await RegisterUser();

            result2.Should().NotBeNull();
            result2.Should().Be($"userName : tarek already found");

        }

        [Fact]
        public async Task login1()
        {
            var result1 = await _mediator.Send(new LoginQuery() { UserName = "tarek", Password = "Admin@123" });
            result1.Should().Be($"userName or Password Wrong");

        }
        [Fact]
        public async Task login2()
        {
            var registerUser = await RegisterUser();
            var result2 = await _mediator.Send(new LoginQuery() { UserName = "tarek", Password = "Admin@1234" });
            result2.Should().Be($"userName or Password Wrong");

        }
        [Fact]
        public async Task login3()
        {

            var registerUser = await RegisterUser();
            var result3 = await _mediator.Send(new LoginQuery() { UserName = "tarek", Password = "Admin@123" });
            result3.Should().NotBe($"userName or Password Wrong");

        }
        private async Task<string?> RegisterUser()
        {
            var user = new RegisterUserCommand()
            {
                UserName = "tarek",
                Email = "tarek@inovola.com.sa",
                Password = "Admin@123",
                Mobile = "0542145854"
            };

            return await _mediator.Send(user);

        }
    }
}
