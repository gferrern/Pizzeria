using pizzeria.Domain;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Infraestructure{
    public class PizzeriaContext:DbContext
    {

        public PizzeriaContext (DbContextOptions<PizzeriaContext> options)
            : base(options)
        {
        }

        public DbSet<User> User{get; set;}
    }
}