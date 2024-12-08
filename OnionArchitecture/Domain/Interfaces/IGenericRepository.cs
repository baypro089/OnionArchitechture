using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T, TDto1, TDto2> 
        where T : class
        where TDto1 : class
        where TDto2 : class
    {
        Task<IEnumerable<TDto1>> GetAllAsync();
        Task<TDto1> GetByIdAsync(int id);
        Task<bool> AddAsync(TDto2 dto);
        Task<bool> UpdateAsync(int id, TDto2 dto);
        Task<bool> DeleteAsync(int id);
    }
}
