using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(string UserName, string FullName, string email ,string Password);
        Task<string> AuthenticateAsync(string UserName, string Password);
    }
}
