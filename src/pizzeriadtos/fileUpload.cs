using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace pizzeria.Dtos{
    public class fileUpload{
        [Required][MaxLength(16)]
        public string FileName {get;set;}
        [Required]
        public IFormFile FileData { get; set; }
    }
}
