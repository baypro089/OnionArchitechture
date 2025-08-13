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
    public class VerifyEmailController : ControllerBase
    {
        private readonly IVerifyEmailService _verifyEmailService;
        public VerifyEmailController(IVerifyEmailService verifyEmailService)
        {
            _verifyEmailService = verifyEmailService;
        }

        [HttpPost("")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyEmail([FromBody]VerifyEmailDTO verifyEmailDTO)
        {
            try
            {
                await _verifyEmailService.HandleVerifyEmail(verifyEmailDTO);
                return Ok("Your email has been verified successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request. " + ex.Message);
            }
        }

        [HttpPost("resend")]
        [AllowAnonymous]
        public async Task<IActionResult> ResendVerifyEmail([FromForm] string email)
        {
            try
            {
                await _verifyEmailService.HandleResendVerifyEmail(email);
                return Ok("A new verification email has been sent.");
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request. " + ex.Message);
            }
        }
    }
}
