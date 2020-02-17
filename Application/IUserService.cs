using pizzeria.Dtos;
using System;
namespace pizzeria.Application{
    public interface IUserService
    {
        void Register(UserRegister userRegister);
    }
}