using Microsoft.EntityFrameworkCore;
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
        public void Add(TempImage image)
        {
            using (var multiplexer = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                var db = multiplexer.GetDatabase();
                db.StringSet("bytearray", image);
            }
        }
    }
}