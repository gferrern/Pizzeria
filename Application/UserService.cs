using pizzeria.Domain;
using pizzeria.Dtos;

namespace pizzeria.Application{
    public class UserService : IUserService
    {
        public void Register(UserRegister userRegister)
        {
            var user  = User.Create(userRegister);
            // TODO:INFRAESTRUCTURA
        }
    }
}