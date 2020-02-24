using pizzeria.Dtos;
using System;
namespace pizzeria.Application{
    public interface IUploadService
    {
        void Upload(fileUpload fileupload);
    }
}