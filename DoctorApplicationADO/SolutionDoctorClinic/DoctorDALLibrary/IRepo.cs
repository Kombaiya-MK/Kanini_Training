using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDALLibrary
{
    public interface IRepo<T,K>
    {
        T Get(K id);
        bool Add(T item);
        bool Delete(K id);
        bool Update(T item);
        T[] GetAll();

    }
}
