using pizzeria.Domain;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Infraestructure{
    public class PizzeriaContext: DbContext,IUserRepository,IUploadRepository,IIngredientRepository
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
        public DbSet<FileUploader> FileUploader{get; set;}
        public DbSet<Ingredient> Ingredient{get; set;}

    }
}