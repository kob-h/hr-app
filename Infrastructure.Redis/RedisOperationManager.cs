using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Abstractions;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Infrastructure.Redis
{
    public class RedisOperationManager : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisOperationManager(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }
        public async Task<bool> SetObjectValueAsync<T>(string key, T value, TimeSpan? expiry = null, int dbIndex = -1)
        {
            var res =  await _connectionMultiplexer
                .GetDatabase(dbIndex)
                .StringSetAsync(key, JsonConvert.SerializeObject(value), expiry);

            return true;
        }

        public async Task<T> GetDeserializedValueAsync<T>(string key, int dbIndex = -1)
        {
            var stringValue = await _connectionMultiplexer
                .GetDatabase(dbIndex)
                .StringGetAsync(key);

            return stringValue.HasValue ? JsonConvert.DeserializeObject<T>(stringValue) : default(T);
        }
        public async Task<bool> Delete(string key, int dbIndex = -1)
        {
            return await _connectionMultiplexer
                .GetDatabase(dbIndex)
                .KeyDeleteAsync(key);
        }
    }
}
