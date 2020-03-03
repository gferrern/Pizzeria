using System;
using Microsoft.Extensions.Configuration;
using pizzeria.Domain;
using StackExchange.Redis;

namespace pizzeria.Infraestructure
{
    public interface ITempImageRepository
    {
        void Add(TempImage image);

    }

    public class TempImageRepository : ITempImageRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connection;
        public TempImageRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = _configuration.GetValue<string>("redisConnection");
        }
        public void Add(TempImage image)
        {
            try
            {
                using (var multiplexer = ConnectionMultiplexer.Connect(_connection))
                {
                    var db = multiplexer.GetDatabase();
                    db.SetAdd(image.Id.ToString(), image.Image);
                    db.KeyExpire(image.Id.ToString(), TimeSpan.FromHours(12));
                }
            }
            catch (RedisException e)
            {
                Console.WriteLine("Exception: {0}",e);
            }

        }
    }
}