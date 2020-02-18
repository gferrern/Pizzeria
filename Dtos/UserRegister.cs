using System;
using System.ComponentModel.DataAnnotations;

namespace pizzeria.Dtos{
    public class UserRegister{
        [Required]
        public string Name {get;set;}
        [Required]
        public string Email{get;set;}
        [Required]
        public string PassWord{get;set;}
    }
}
