using Microsoft.EntityFrameworkCore;
using pizzeria.Domain;

namespace pizzeria.Infraestructure
{
    public interface IUoW
    {
        int SaveChanges();
    }
    public interface IUserRepository : IUoW
    {
        DbSet<User> User { get; set; }

    }
}