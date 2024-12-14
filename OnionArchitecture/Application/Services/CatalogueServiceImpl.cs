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
    public class CatalogueServiceImpl : ICatalogueService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CatalogueServiceImpl(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(CreateCatalogueDTO dto)
        {
            var repository = _unitOfWork.Repository<Catalogue, CatalogueDTO, CreateCatalogueDTO>();
            await repository.AddAsync(dto);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var repository = _unitOfWork.Repository<Catalogue, CatalogueDTO, CreateCatalogueDTO>();
            await repository.DeleteAsync(id);
            return await _unitOfWork.CompleteAsync() > 0;
        }

        public async Task<IEnumerable<CatalogueDTO>> GetAllAsync()
        {
            var repository = _unitOfWork.Repository<Catalogue, CatalogueDTO, CreateCatalogueDTO>();
            return await repository.GetAllAsync();
        }

        public async Task<CatalogueDTO> GetByIdAsync(int id)
        {
            var repository = _unitOfWork.Repository<Catalogue, CatalogueDTO, CreateCatalogueDTO>();
            return await repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, CreateCatalogueDTO dto)
        {
            var repository = _unitOfWork.Repository<Catalogue, CatalogueDTO, CreateCatalogueDTO>();
            await repository.UpdateAsync(id, dto);
            return await _unitOfWork.CompleteAsync() > 0;
        }
    }
}
