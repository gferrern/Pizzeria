using System;
using System.ComponentModel.DataAnnotations;

namespace pizzeria.Dtos{
    public class UserRegister{
        [Required][MaxLength(16)]
        public string Name {get;set;}
        [Required][EmailAddress]
        public string Email{get;set;}
        [Required][MinLength(8)][MaxLength(16)]
        public string PassWord{get;set;}
    }
}
