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
    public class BookServiceImpl : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookServiceImpl(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(CreateBookDTO dto)
        {
            var repository = _unitOfWork.Repository<Book, BookDTO, CreateBookDTO>();
            await repository.AddAsync(dto);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var repository = _unitOfWork.Repository<Book, BookDTO, CreateBookDTO>();
            await repository.DeleteAsync(id);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<IEnumerable<BookDTO>> GetAllAsync()
        {
            var repository = _unitOfWork.Repository<Book, BookDTO, CreateBookDTO>();
            return await repository.GetAllAsync();
        }

        public async Task<BookDTO> GetByIdAsync(int id)
        {
            var repository = _unitOfWork.Repository<Book, BookDTO, CreateBookDTO>();
            return await repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, CreateBookDTO dto)
        {
            var repository = _unitOfWork.Repository<Book, BookDTO, CreateBookDTO>();
            await repository.UpdateAsync(id, dto);
            return await _unitOfWork.CompleteAsync() > 0;
        }
    }
}
