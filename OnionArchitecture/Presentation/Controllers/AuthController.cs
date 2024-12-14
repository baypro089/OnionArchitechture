using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] string UserName, [FromForm] string FullName, [FromForm] string Email, [FromForm] string Password)
        {
            var token = await _authService.RegisterAsync(UserName, FullName, Email, Password);
            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] string UserName, [FromForm] string Password)
        {
            var token = await _authService.AuthenticateAsync(UserName, Password);
            return Ok(new { Token = token });
        }
    }
}
