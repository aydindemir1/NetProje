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
        public IDatabase Database;

        public RedisCacheService(string url)
        {
            var connectionMultiplexer = ConnectionMultiplexer.Connect(url);


            connectionMultiplexer.ConnectionFailed += ConnectionMultiplexer_ConnectionFailed;


            Database = connectionMultiplexer.GetDatabase(1);
        }

        private void ConnectionMultiplexer_ConnectionFailed(object? sender, ConnectionFailedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
