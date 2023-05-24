using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModelLibrary;

namespace UserDALLibrary
{
    public interface IRepo<T,K>
    {
        bool Add(T item);

        bool Delete(K id);
        bool Update(T item);
        T Get(K id);
        ICollection<T> GetAll();
    }
}
