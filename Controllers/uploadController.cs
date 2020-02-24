using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizzeria.Dtos;
using pizzeria.Application;

namespace pizzeria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class uploadController : ControllerBase
    {

        private readonly ILogger<uploadController> _logger;
        private readonly IUploadService _uploadService;

        public uploadController(ILogger<uploadController> logger,IUploadService uploadService)
        {
            _logger = logger;
            _uploadService = uploadService;
           
        }

        [HttpPost]
        public ActionResult fileUpload([FromForm]fileUpload file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            //_uploadService.Upload(file);
            return Ok();

        }
    }
}
