using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGenericRepository<T, TDto1, TDto2> 
        where T : class
        where TDto1 : class
        where TDto2 : class
    {
        Task<IEnumerable<TDto1>> GetAllAsync();
        Task<TDto1> GetByIdAsync(int id);
        Task AddAsync(TDto2 dto);
        Task UpdateAsync(int id, TDto2 dto);
        Task DeleteAsync(int id);
    }
}
