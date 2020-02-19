using pizzeria.Dtos;

namespace pizzeria.Infraestructure
{
    public interface IUserRepository{
        void Insert (UserRegister userRegister);
        void Save (PizzeriaContext pizzeriaContext);
    }
}