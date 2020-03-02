using pizzeria.Domain;
using pizzeria.Infraestructure;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace pizzeria.Application
{
    public class PizzeriaService : IPizzeriaService
    {
        private readonly IPizzeriaRepository _repositoryPizzeria;
        public PizzeriaService(IPizzeriaRepository repositoryPizzeria)
        {
            _repositoryPizzeria = repositoryPizzeria;
        }

        public object Upload(byte[] image)
        {
            var tempImage = TempImage.Create(image);
            //Ahora REDIS
            return new {
                Id = tempImage.Id
            };
        }
    }
}