using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizzeria.Dtos;
using pizzeria.Application;
using CsvHelper;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace pizzeria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {

        private readonly ILogger<IngredientController> _logger;
        private readonly IIngredientService _ingredientService;
        public IngredientController(ILogger<IngredientController> logger, IIngredientService uploadService)
        {
            _logger = logger;
            _ingredientService = uploadService;

        }

        [HttpPost]
        public IActionResult ingredient([FromForm]IFormFile csv)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            using (MemoryStream ms = new MemoryStream())
            {
                csv.CopyTo(ms);
                using (TextReader fileReader = new StreamReader(ms))
                {
                    var csvReader= new CsvReader(fileReader, System.Globalization.CultureInfo.InvariantCulture);
                    var result = csvReader.GetRecords<IngredientFileRead>();
                    _ingredientService.AddRange(result);
                    return Ok();
                }
            }


            //utilizar GetFile(file)    }
        }
    }
}