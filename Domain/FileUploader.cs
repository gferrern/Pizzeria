using System;
using pizzeria.Dtos;
using Microsoft.AspNetCore.Http;

namespace pizzeria.Domain{
    public class FileUploader{
        public Guid Id{get;set;}
        public string FileName {get;set;}
        public IFormFile FileData{get;set;}

        public static FileUploader prepareUpload(fileUpload fileupload){
            var file = new FileUploader();
            file.Id = Guid.NewGuid();
            file.FileName = fileupload.FileName;
            file.FileData = fileupload.FileData;
            return file;
        }

    }
}