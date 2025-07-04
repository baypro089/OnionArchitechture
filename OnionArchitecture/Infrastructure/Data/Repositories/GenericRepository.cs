﻿using AutoMapper;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class GenericRepository<T, TDto1, TDto2> : IGenericRepository<T, TDto1, TDto2>
        where T : class
        where TDto1 : class
        where TDto2 : class
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = _context.Set<T>();
        }

        // Lấy tất cả các bản ghi và chuyển sang DTO
        public async Task<IEnumerable<TDto1>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return _mapper.Map<IEnumerable<TDto1>>(entities);
        }

        // Lấy bản ghi theo Id
        public async Task<TDto1> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return _mapper.Map<TDto1>(entity);
        }

        // Thêm mới bản ghi
        public async Task AddAsync(TDto2 dto)
        {
            var entity = _mapper.Map<T>(dto);
            await _dbSet.AddAsync(entity);
        }

        // Cập nhật bản ghi
        public async Task UpdateAsync(int id, TDto2 dto)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) throw new KeyNotFoundException("Entity not found");

            _mapper.Map(dto, entity);
            _dbSet.Update(entity);
        }

        // Xóa bản ghi
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) throw new KeyNotFoundException("Entity not found");

            _dbSet.Remove(entity);
        }
    }
}
