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
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger,IUserService userService)
        {
            _logger = logger;
            _userService = userService;
           
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserRegister userRegister)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            _userService.Register(userRegister);
            return Ok();

        }
    }
}
