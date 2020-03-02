using pizzeria.Domain;
using Microsoft.AspNetCore.Http;

namespace pizzeria.Application
{
    public interface IPizzeriaService
    {        
        object Upload(byte[] image);
    }
}