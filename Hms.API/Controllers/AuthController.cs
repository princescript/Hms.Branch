using Hms.Application.Dtos.Auth;
using Hms.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _service;
        public AuthController(IUsersService service)
        {
            _service = service;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<object>> RegisterAsync(RegisterDto dto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            
            }
            var user = await _service.RegisterAsync(dto);
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<object>> LoginAsync(LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var user = await _service.LoginAsync(dto);
            return Ok(user);
        }
    }
}
