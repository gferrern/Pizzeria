using pizzeria.Domain;

namespace pizzeria.Application{
    public interface IUploadService
    {
        void Upload(FileUploader fileupload);
    }
}