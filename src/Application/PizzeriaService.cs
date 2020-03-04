using pizzeria.Domain;
using pizzeria.Infraestructure;
using System.IO;

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

        public object saveToDB(byte[] image)
        {
            var dto = new Dtos.PizzeriaDTO();
            dto.Name = "Pepe";
            using (var memoryStream = new MemoryStream(image))
            {
                dto.Image = memoryStream.ToArray();
            }
            var tmppizzeria = Pizzeria.Create(dto);
            _repositoryPizzeria.Pizzeria.Add(tmppizzeria);
            return new {
                Id = tmppizzeria.Id
            };
        }
    }
}