using pizzeria.Domain;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
namespace pizzeria.Infraestructure
{
    public class PizzeriaContext : DbContext, IUserRepository, IPizzeriaRepository, IIngredientRepository
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(c => new { c.Id });
            modelBuilder.Entity<Ingredient>().HasKey(c => new { c.Id });
            modelBuilder.Entity<Pizzeria>().HasKey(c => new { c.Id });
            
            //one to many
            modelBuilder.Entity<Pizzeria>()
                            .HasMany<Image>(p => p.Images)
                            .WithOne().IsRequired();
                            
            //many to many
            modelBuilder.Entity<PizzeriaIngredient>()
                            .HasMany<Pizzeria>(pi => pi.Pizza)
                            .WithOne().IsRequired(); 
            modelBuilder.Entity<Pizzeria>()
                            .HasMany<PizzeriaIngredient>(pi => pi.Ingredients)
                            .WithOne().IsRequired(); 
        }
                           
        public DbSet<User> User { get; set; }
        public DbSet<Pizzeria> Pizzeria { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }

    }
}