using System;
using Infrastructure.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Infrastructure.Redis
{
    public static class ConfigurationExtensions
    {
        /// <summary>
        ///    
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="configuration">The redis connection string</param>
        /// <returns></returns>
        public static IServiceCollection AddRedis(this IServiceCollection collection, string configuration)
        {
            collection.AddTransient<ICacheService, RedisOperationManager>();
            collection.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(configuration));

            return collection;
        }
    }
}
