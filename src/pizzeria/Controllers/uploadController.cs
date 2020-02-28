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
    public class uploadController : ControllerBase
    {

        private readonly ILogger<uploadController> _logger;
        private readonly IUploadService _uploadService;

        public uploadController(ILogger<uploadController> logger, IUploadService uploadService)
        {
            _logger = logger;
            _uploadService = uploadService;

        }

        [HttpPost]
        public IActionResult upload([FromBody]fileUpload file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var fileuploader = new FileUploader();
            fileuploader.Id = Guid.NewGuid();
            _uploadService.Upload(fileuploader);
            return Ok();

        }
    }
}
