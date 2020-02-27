using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizzeria.Application;

namespace pizzeria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StreamController : ControllerBase
    {

        private readonly ILogger<StreamController> _logger;
        private readonly IStreamService _streamController;

        public StreamController(ILogger<StreamController> logger, IStreamController streamController)
        {
            _logger = logger;
            _streamController = streamController;

        }

        [HttpPost]
        public IActionResult uploadCSV([FromBody]IStream csv)
        {
            return Ok();
        }
    }
}
