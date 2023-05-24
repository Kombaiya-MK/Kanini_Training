using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowBullDALLibrary
{
    public interface IRepo<T,K>
    {
        T Get(K key);
        int Add(T item);

        ICollection<T> GetAll(K key);



    }
}
