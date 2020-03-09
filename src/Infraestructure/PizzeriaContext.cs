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
            modelBuilder.Entity<Ingredient>().Property(i => i.Price).HasColumnType("decimal(5,2)");

            //one to many
            modelBuilder.Entity<Pizzeria>()
                            .HasMany<Image>(p => p.Images)
                            .WithOne().IsRequired();

            //many to many
            modelBuilder.Entity<PizzeriaIngredient>()
                           .HasKey(c => new { c.Id });


            modelBuilder.Entity<PizzeriaIngredient>()
                .HasOne(bc => bc.Pizza)
                .WithMany(p => p.Ingredients).IsRequired();

            modelBuilder.Entity<PizzeriaIngredient>()
                .HasOne(bc => bc.Ingredient)
                .WithMany().IsRequired();
        }

        public DbSet<User> User { get; set; }
        public DbSet<Pizzeria> Pizzeria { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }

    }
}