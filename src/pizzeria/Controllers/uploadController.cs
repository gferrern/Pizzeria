using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizzeria.Dtos;
using pizzeria.Application;
using pizzeria.Domain;

namespace pizzeria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {

        private readonly ILogger<UploadController> _logger;
        private readonly IUploadService _UploadService;

        public UploadController(ILogger<UploadController> logger, IUploadService UploadService)
        {
            _logger = logger;
            _UploadService = UploadService;

        }

        [HttpPost]
        public IActionResult Upload([FromBody]fileUpload file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var fileUploader = new FileUploader();
            fileUploader.Id = Guid.NewGuid();
            _UploadService.Upload(fileUploader);
            return Ok();

        }
    }
}
