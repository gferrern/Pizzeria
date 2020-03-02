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
        private readonly ITempImageRepository _tempImageRepository;
        public PizzeriaService(IPizzeriaRepository repositoryPizzeria, ITempImageRepository tempImageRepository)
        {
            _repositoryPizzeria = repositoryPizzeria;
            _tempImageRepository = tempImageRepository;
        }

        public object Upload(byte[] image)
        {
            var tempImage = TempImage.Create(image);
            _tempImageRepository.Add(tempImage);
            return new {
                Id = tempImage.Id
            };
        }
    }
}