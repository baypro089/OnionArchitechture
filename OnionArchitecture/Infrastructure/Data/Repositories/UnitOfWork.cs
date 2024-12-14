using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAppDbContext _context;
        private readonly IUserService _userService;
        private readonly Dictionary<Type, object> _repositories = new();
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(IAppDbContext context, IUserService userService, IServiceProvider serviceProvider)
        {
            _context = context;
            _userService = userService;
            _serviceProvider = serviceProvider;
        }

        public IGenericRepository<T, TDto1, TDto2> Repository<T, TDto1, TDto2>()
            where T : class
            where TDto1 : class
            where TDto2 : class
        {
            var key = typeof(T);

            if (!_repositories.ContainsKey(key))
            {
                var repository = _serviceProvider.GetRequiredService<IGenericRepository<T, TDto1, TDto2>>();
                _repositories[key] = repository;
            }

            return (IGenericRepository<T, TDto1, TDto2>)_repositories[key];
        }

        public async Task<int> CompleteAsync()
        {
            var userId = _userService.GetCurrentUserId();  // Lấy ID người dùng hiện tại

            // Lặp qua các thực thể có interface IAuditableEntity và cập nhật thông tin người dùng
            foreach (var entry in _context.ChangeTracker.Entries<IAuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = userId;  // Gắn thông tin người tạo
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedBy = userId;  // Gắn thông tin người sửa
                    entry.Entity.ModifiedDate = DateTime.UtcNow;
                }
            }

            return await _context.SaveChangesAsync();
        }
    }
}
