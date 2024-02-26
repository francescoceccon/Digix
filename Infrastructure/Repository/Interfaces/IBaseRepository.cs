using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task Insert(T entity);
        Task<IEnumerable<T>> SelectList();
    }
}
