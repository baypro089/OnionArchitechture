using Domain.Entities;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Application.DTOs;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailService = emailService;
        }

        public async Task<string> RegisterAsync(RegisterDTO registerDTO)
        {
            try
            {
                // Tạo đối tượng user mới
                var user = new ApplicationUser
                {
                    UserName = registerDTO.UserName,
                    FullName = registerDTO.FullName,
                    Email = registerDTO.Email  // Giả sử bạn lấy email từ userName hoặc làm tùy chọn
                };

                // Tạo người dùng trong Identity
                var result = await _userManager.CreateAsync(user, registerDTO.Password);

                if (!result.Succeeded)
                {
                    throw new Exception("User registration failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
                else {
                    await _userManager.AddToRoleAsync(user, "User");
                }

                // Trả về token sau khi đăng ký thành công (nếu cần)
                var token = _tokenService.GenerateToken(user);

                var encodedToken = Uri.EscapeDataString(token);

                var confirmLink = $"https://yourfrontend.com/verify-email?email={user.Email}&token={encodedToken}";

                await _emailService.SendEmailAsync(user.Email, "Xác nhận email", $"Click để xác nhận: {confirmLink}");

                return token;
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc xử lý lỗi tùy chỉnh
                throw new Exception("Registration failed.", ex);
            }
        }

        public async Task<string> AuthenticateAsync(LoginDTO loginDTO)
{
            var user = await _userManager.FindByNameAsync(loginDTO.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                throw new Exception("Invalid username or password.");
            }
            return _tokenService.GenerateToken(user);
        }
    }
}
