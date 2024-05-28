using Microsoft.EntityFrameworkCore.Storage;
using NetProje.Service.CacheService.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IDatabase = StackExchange.Redis.IDatabase;

namespace NetProje.Service.CacheService.RedisCacheService
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDatabase _database;

        public RedisCacheService(string url)
        {
            var connectionMultiplexer = ConnectionMultiplexer.Connect(url);
            connectionMultiplexer.ConnectionFailed += ConnectionMultiplexer_ConnectionFailed;
            _database = connectionMultiplexer.GetDatabase(1);
        }

        private void ConnectionMultiplexer_ConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(string key)
        {
            await _database.KeyDeleteAsync(key);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
        {
            var json = JsonSerializer.Serialize(value);
            await _database.StringSetAsync(key, json, expiration);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);
            return value.HasValue ? JsonSerializer.Deserialize<T>(value) : default;
        }
    }

}
