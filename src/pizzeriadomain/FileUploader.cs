using System;
using pizzeria.Dtos;
using Microsoft.AspNetCore.Http;

namespace pizzeria.Domain{
    public class FileUploader{
        public Guid Id{get;set;}
        public string FileName {get;set;}
        public IFormFile FileData{get;set;}
    }
}