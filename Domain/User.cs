using System;
using pizzeria.Dtos;
namespace pizzeria.Domain{
    public class User{
        public Guid Id{get;set;}
        public string Name {get;set;}
        public string Email{get;set;}
        public string PassWord{get;set;}
        public static User Create(UserRegister userRegister){
            var user = new User();
            user.Id = Guid.NewGuid();
            user.Name = userRegister.Name;
            user.Email = userRegister.Email;
            user.PassWord = userRegister.PassWord; //TODO:conver password to SHA256;
            return user;

        }
    }
}