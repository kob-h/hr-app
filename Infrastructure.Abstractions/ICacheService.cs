using System;
using System.Threading.Tasks;

namespace Infrastructure.Abstractions
{
    public interface ICacheService
    {
        public Task<bool> SetObjectValueAsync<T>(string key, T value, TimeSpan? expiry = null, int dbIndex = -1);
        public Task<T> GetDeserializedValueAsync<T>(string key, int dbIndex = -1);

        public Task<bool> Delete(string key, int dbIndex = -1);
    }
}
