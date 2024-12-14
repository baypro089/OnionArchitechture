using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<T, TDto1, TDto2> Repository<T, TDto1, TDto2>() 
            where T : class
            where TDto1 : class
            where TDto2 : class;
        Task<int> CompleteAsync();
    }
}
