using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeModelLibrary;

namespace EmployeeDALLibrary
{
    public interface IRepo<T,K>
    {
        void Add(T item );
        T Get(K id);
        ICollection <T> GetAll();
        bool Update(T item);
        bool Delete(K id);

    }
}
