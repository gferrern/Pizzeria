using pizzeria.Domain;
using pizzeria.Dtos;
using pizzeria.Infraestructure;

namespace pizzeria.Application{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repositoryUser;
        public UserService(IUserRepository repositoryUser){
            _repositoryUser = repositoryUser;
        }
        //contrustor
        
        public void Register(UserRegister userRegister)
        {
            var user  = User.Create(userRegister);            
            _repositoryUser.User.Add(user);
            _repositoryUser.SaveChanges();
            
        }
        public void Upload(fileUpload fileupload)
        {
            var file  = File.Upload(fileupload);            
            _repositoryUser.SaveChanges();
            
        }
    }
}