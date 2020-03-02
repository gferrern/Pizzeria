using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using pizzeria.utils;
using System.IO;

namespace pizzeria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StreamController : ControllerBase
    {

        private readonly ILogger<StreamController> _logger;
        private readonly IStreamService _streamService;

        public StreamController(ILogger<StreamController> logger, IStreamService streamService)
        {
            _logger = logger;
            _streamService = streamService;

        }

        [HttpPost]
        public IActionResult Post([FromForm]IFormFile csv)
        {
            
            //StreamService
            return Ok();
        }
      
    }
}
