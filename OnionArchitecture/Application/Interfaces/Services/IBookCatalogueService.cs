using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IBookCatalogueService
    {
        Task<IEnumerable<BookCatalogueDTO>> GetAllAsync();
        Task<BookCatalogueDTO> GetByIdAsync(int id);
        Task<bool> AddAsync(CreateBookCatalogueDTO dto);
        Task<bool> UpdateAsync(int id, CreateBookCatalogueDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
