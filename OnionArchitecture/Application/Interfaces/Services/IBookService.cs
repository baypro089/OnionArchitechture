using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllAsync();
        Task<BookDTO> GetByIdAsync(int id);
        Task<bool> AddAsync(CreateBookDTO dto);
        Task<bool> UpdateAsync(int id, CreateBookDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
