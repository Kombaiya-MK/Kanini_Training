using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowBullBLLibrary
{
    public interface IAttempts<T,K>
    {
        ICollection<T> GetAttempts(K key);
        int AddAttempts(T attempt);    
    }
}
