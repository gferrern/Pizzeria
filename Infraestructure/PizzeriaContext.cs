using pizzeria.Domain;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Infraestructure{
    public class PizzeriaContext: DbContext,IUserRepository,IUploadRepository
    {

        public PizzeriaContext (DbContextOptions<PizzeriaContext> options)
            : base(options)
        {
            
        }
        public override int SaveChanges(){
            try{
                return base.SaveChanges();
            }
            catch{
                throw;
            }
        }

        public DbSet<User> User{get; set;}
        public DbSet<File> File{get; set;}

    }
}