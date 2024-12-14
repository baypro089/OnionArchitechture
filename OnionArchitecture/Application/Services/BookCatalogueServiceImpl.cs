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
    public class BookCatalogueServiceImpl : IBookCatalogueService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookCatalogueServiceImpl(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(CreateBookCatalogueDTO dto)
        {
            var repository = _unitOfWork.Repository<BookCatalogue, BookCatalogueDTO, CreateBookCatalogueDTO>();
            await repository.AddAsync(dto);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var repository = _unitOfWork.Repository<BookCatalogue, BookCatalogueDTO, CreateBookCatalogueDTO>();
            await repository.DeleteAsync(id);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<IEnumerable<BookCatalogueDTO>> GetAllAsync()
        {
            var repository = _unitOfWork.Repository<BookCatalogue, BookCatalogueDTO, CreateBookCatalogueDTO>();
            return await repository.GetAllAsync();
        }

        public async Task<BookCatalogueDTO> GetByIdAsync(int id)
        {
            var repository = _unitOfWork.Repository<BookCatalogue, BookCatalogueDTO, CreateBookCatalogueDTO>();
            return await repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, CreateBookCatalogueDTO dto)
        {
            var repository = _unitOfWork.Repository<BookCatalogue, BookCatalogueDTO, CreateBookCatalogueDTO>();
            await repository.UpdateAsync(id, dto);
            return await _unitOfWork.CompleteAsync() > 0;
        }
    }
}
