using pizzeria.Domain;
using pizzeria.Dtos;
using pizzeria.Infraestructure;
using System.IO;

namespace pizzeria.Application
{
    public class PizzeriaService : IPizzeriaService
    {
        private readonly IPizzeriaRepository _repositoryPizzeria;
        private readonly ITempImageRepository _tempImageRepository;
        private readonly IImageServerRepository _imageRepository;
        public PizzeriaService(IPizzeriaRepository repositoryPizzeria, ITempImageRepository tempImageRepository, IImageServerRepository imageRepository)
        {
            _repositoryPizzeria = repositoryPizzeria;
            _tempImageRepository = tempImageRepository;
            _imageRepository = imageRepository;
            
        }

        public object Upload(byte[] image)
        {
            var tempImage = TempImage.Create(image);
            _tempImageRepository.Add(tempImage);
            return new {
                Id = tempImage.Id
            };
        }

        public object Add(PizzeriaDTO createPIzza)
        {
            var image = _tempImageRepository.Get(createPIzza.Image);
            _tempImageRepository.Remove(createPIzza.Image);
            _imageRepository.GetRoutes(image);
            return null;
        }
    }
}