using Microsoft.EntityFrameworkCore;
using pizzeria.Domain;

namespace pizzeria.Infraestructure
{
    public interface IPizzeriaW
    {
        int SaveChanges();
    }
    public interface IPizzeriaRepository : IPizzeriaW
    {
        DbSet<Pizzeria> Pizzeria { get; set; }

    }
}