using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pizzeria.Dtos;
using pizzeria.Application;
using pizzeria.Domain;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
    
namespace pizzeria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {

        private readonly ILogger<UploadController> _logger;
        private readonly IUploadService _UploadService;

        private readonly IDistributedCache _cache;

        public UploadController(ILogger<UploadController> logger, IUploadService UploadService, IDistributedCache cache)
        {
            _logger = logger;
            _UploadService = UploadService;
            _cache = cache;
        }

        [HttpPost]
        public IActionResult upload([FromBody]fileUpload file)
        {
            var currentTimeUTC = DateTime.UtcNow.ToString();
            byte[] encodedCurrentTimeUTC = Encoding.UTF8.GetBytes(currentTimeUTC);
            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(20));
            _cache.Set("cachedTimeUTC", encodedCurrentTimeUTC, options);
            _cache.Set("image", file.FileData, options);
            return Ok();
        }
    }
}
