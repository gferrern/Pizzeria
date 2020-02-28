using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizzeria.Dtos;
using pizzeria.Application;

namespace pizzeria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {

        private readonly ILogger<IngredientController> _logger;
        private readonly IIngredientService _ingredientService;
        public IngredientController(ILogger<IngredientController> logger,IIngredientService uploadService)
        {
            _logger = logger;
            _ingredientService = uploadService;
           
        }

        [HttpPost]
        public IActionResult ingredient([FromBody]IngredientFileRead ingredientFileRead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            _ingredientService.Upload(ingredientFileRead);
            return Ok();
        }
    }
}
