using Domain.Entities;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> RegisterAsync(string userName, string fullName, string email, string password)
        {
            try
            {
                // Tạo đối tượng user mới
                var user = new ApplicationUser
                {
                    UserName = userName,
                    FullName = fullName,
                    Email = email  // Giả sử bạn lấy email từ userName hoặc làm tùy chọn
                };

                // Tạo người dùng trong Identity
                var result = await _userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    throw new Exception("User registration failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
                else {
                    await _userManager.AddToRoleAsync(user, "User");
                }

                // Trả về token sau khi đăng ký thành công (nếu cần)
                var token = _tokenService.GenerateToken(user);

                return token;
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc xử lý lỗi tùy chỉnh
                throw new Exception("Registration failed.", ex);
            }
        }

        public async Task<string> AuthenticateAsync(string UserName, string Password)
{
            var user = await _userManager.FindByNameAsync(UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, Password))
            {
                throw new Exception("Invalid username or password.");
            }
            return _tokenService.GenerateToken(user);
        }
    }
}
