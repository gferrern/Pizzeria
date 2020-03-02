using pizzeria.Domain;
using Microsoft.AspNetCore.Http;

namespace pizzeria.Application
{
    public interface IUploadService
    {
        void uploadToHardDisk(FileUploader fileupload);
        void upload(FileUploader file);
    }
}