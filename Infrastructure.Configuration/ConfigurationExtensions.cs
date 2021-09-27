using System;
using Infrastructure.Email;
using Infrastructure.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddInfrastructureLayerDependencies(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddRedis(configuration.GetValue<string>("Redis:Connection"));
            collection.ConfigureFluentEmail(
                configuration.GetValue<string>("FluentEmail:Host"),
                configuration.GetValue<int>("FluentEmail:Port"),
                configuration.GetValue<bool>("FluentEmail:EnableSSL"),
                configuration.GetValue<string>("FluentEmail:DefaultFromEmail"));

            return collection;
        }
    }
}
