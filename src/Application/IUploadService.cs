using pizzeria.Domain;
using Microsoft.AspNetCore.Http;

namespace pizzeria.Application{
    public interface IUploadService
    {
        void Upload(FileUploader fileupload);
        void Upload2(IFormFile file);
    }
}