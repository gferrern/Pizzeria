using pizzeria.Domain;
using pizzeria.Dtos;

namespace pizzeria.Application{
    public class UserService : IUserService
    {
        //contrustor
        public void Register(UserRegister userRegister)
        {
            var user  = User.Create(userRegister);
            //userReposiroty.User.Add(user);
            //userReposiroty.Savechanges()
        }
    }
}