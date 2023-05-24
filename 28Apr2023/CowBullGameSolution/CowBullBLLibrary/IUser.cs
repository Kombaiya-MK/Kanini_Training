using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowBullBLLibrary
{
    public interface IUser<T , K>
    {
        int AddUser(T user);
        T GetUser(K key);


    }
}
