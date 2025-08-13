using Application.DTOs;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class VerifyEmailService : IVerifyEmailService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;

        public VerifyEmailService(UserManager<ApplicationUser> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task HandleVerifyEmail(VerifyEmailDTO verifyEmailDTO)
        {
            var user = await _userManager.FindByEmailAsync(verifyEmailDTO.Email);
            if (user == null)
                throw new Exception("User not found");

            var decodedToken = Uri.UnescapeDataString(verifyEmailDTO.Token);
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        public async Task HandleResendVerifyEmail(string email) 
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) 
                throw new Exception("User not found");
            if (user.EmailConfirmed)
                throw new Exception("Email is already confirmed");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = Uri.EscapeDataString(token);
            var confirmLink = $"https://yourfrontend.com/verify-email?email={user.Email}&token={encodedToken}";

            await _emailService.SendEmailAsync(user.Email, "Xác nhận email", $"Vui lòng xác nhận tài khoản của bạn bằng cách bấm vào link: {confirmLink}");
        }
        
    }
}
