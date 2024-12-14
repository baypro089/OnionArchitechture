using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GenreServiceImpl : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreServiceImpl(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(CreateGenreDTO dto)
        {
            var repository = _unitOfWork.Repository<Genre, GenreDTO, CreateGenreDTO>();
            await repository.AddAsync(dto);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var repository = _unitOfWork.Repository<Genre, GenreDTO, CreateGenreDTO>();
            await repository.DeleteAsync(id);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<IEnumerable<GenreDTO>> GetAllAsync()
        {
            var repository = _unitOfWork.Repository<Genre, GenreDTO, CreateGenreDTO>();
            return await repository.GetAllAsync();
        }

        public async Task<GenreDTO> GetByIdAsync(int id)
        {
            var repository = _unitOfWork.Repository<Genre, GenreDTO, CreateGenreDTO>();
            return await repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, CreateGenreDTO dto)
        {
            var repository = _unitOfWork.Repository<Genre, GenreDTO, CreateGenreDTO>();
            await repository.UpdateAsync(id, dto);
            return await _unitOfWork.CompleteAsync() > 0;
        }
    }
}
