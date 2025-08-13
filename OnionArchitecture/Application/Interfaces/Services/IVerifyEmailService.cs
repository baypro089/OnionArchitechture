using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IVerifyEmailService
    {
        Task HandleVerifyEmail(VerifyEmailDTO verifyEmailDTO);
        Task HandleResendVerifyEmail(string email);
    }
}
