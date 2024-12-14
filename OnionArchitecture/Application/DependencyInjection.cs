using Application.Services;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            // Đăng ký các service liên quan đến Application Layer
            services.AddScoped<IAuthService, AuthService>();

            // Đăng ký TokenService tại đây
            services.AddScoped<ITokenService, TokenService>();       
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookServiceImpl>();
            services.AddScoped<IGenreService, GenreServiceImpl>();
            services.AddScoped<ICatalogueService, CatalogueServiceImpl>();
            services.AddScoped<IBookCatalogueService, BookCatalogueServiceImpl>();
            return services;
        }
    }
}
