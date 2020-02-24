using System;
using pizzeria.Dtos;
using Microsoft.AspNetCore.Http;

namespace pizzeria.Domain{
    public class File{
        public Guid Id{get;set;}
        public string FileName {get;set;}
        public IFormFile FileData{get;set;}

        public static File Upload(fileUpload fileupload){
            var file = new File();
            file.Id = Guid.NewGuid();
            file.FileName = fileupload.FileName;
            file.FileData = fileupload.FileData;
            return file;
        }

    }
}