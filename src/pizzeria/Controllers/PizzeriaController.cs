using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using pizzeria.Application;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using pizzeria.utils;
using Microsoft.AspNetCore.Http;

namespace pizzeria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzeriasController : ControllerBase
    {

        private readonly ILogger<PizzeriasController> _logger;
        private readonly IPizzeriaService _pizzeriaService;

        private readonly IStreamService _streamService;

        public PizzeriasController(ILogger<PizzeriasController> logger, IPizzeriaService pizzeriaService, IStreamService streamService)
        {
            _logger = logger;
            _pizzeriaService = pizzeriaService;
            _streamService = streamService;

        }

        [HttpPost("uploadImage")]
        public IActionResult Post([FromForm]IFormFile image)
        {
            var result = _streamService.GetBytes(image);
            var imageId = _pizzeriaService.Upload(result);
            return Ok(imageId);
        }


        [HttpPost("savetoDB")]
        public IActionResult savetoDB([FromForm]IFormFile image)
        {
            var result = _streamService.GetBytes(image);
            return Ok(result);
        }
    }
}
