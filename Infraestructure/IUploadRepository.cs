using Microsoft.EntityFrameworkCore;
using pizzeria.Domain;

namespace pizzeria.Infraestructure{
    public interface IUpoW{
        int SaveChanges();
    }
    public interface IUploadRepository:IUpoW
    {       
        DbSet<File> File{get; set;}

    }
}