using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ICatalogueService
    {
        Task<IEnumerable<CatalogueDTO>> GetAllAsync();
        Task<CatalogueDTO> GetByIdAsync(int id);
        Task<bool> AddAsync(CreateCatalogueDTO dto);
        Task<bool> UpdateAsync(int id, CreateCatalogueDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
