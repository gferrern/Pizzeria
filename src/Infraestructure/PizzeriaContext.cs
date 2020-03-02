using pizzeria.Domain;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
namespace pizzeria.Infraestructure
{
    public class PizzeriaContext : DbContext, IUserRepository, IPizzeriaRepository, IIngredientRepository, ITempImageRepository
    {

        public PizzeriaContext(DbContextOptions<PizzeriaContext> options)
            : base(options)
        {

        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void Add(TempImage image)
        {
            using (var multiplexer = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                var db = multiplexer.GetDatabase();
                db.SetAdd("image", image.Image);
            }
        }
        public DbSet<User> User { get; set; }
        public DbSet<Pizzeria> Pizzeria { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }

    }
}