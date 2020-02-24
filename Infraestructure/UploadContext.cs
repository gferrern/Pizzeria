using pizzeria.Domain;
using Microsoft.EntityFrameworkCore;

namespace pizzeria.Infraestructure{
    public class UploadContext: DbContext,IUploadRepository
    {

        public UploadContext (DbContextOptions<UploadContext> options)
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

        public DbSet<File> File{get; set;}

    }
}