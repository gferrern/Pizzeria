using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using pizzeria.utils;

namespace pizzeria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StreamController : ControllerBase
    {

        private readonly ILogger<StreamController> _logger;
        private readonly IStreamService _streamController;

        public StreamController(ILogger<StreamController> logger, IStreamService streamController)
        {
            _logger = logger;
            _streamController = streamController;

        }

        [HttpPost]
        public IActionResult getfile([FromBody]IFormFile csv)
        {
            return Ok();
        }
    }
}
