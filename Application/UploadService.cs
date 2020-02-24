using pizzeria.Domain;
using pizzeria.Dtos;
using pizzeria.Infraestructure;

namespace pizzeria.Application{
    public class UploadService : IUploadService
    {
        private readonly IUploadRepository _repositoryUpload;
        public UploadService(IUploadRepository repositoryUpload){
            _repositoryUpload = repositoryUpload;
        }

        public void Upload(fileUpload fileupload)
        {
            var file  = File.Upload(fileupload);     
            _repositoryUpload.SaveChanges();
            
        }
    }
}