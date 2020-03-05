using pizzeria.Domain;

namespace pizzeria.Application
{
    public interface IPizzeriaService
    {        
        object Upload(byte[] image);
    }
}