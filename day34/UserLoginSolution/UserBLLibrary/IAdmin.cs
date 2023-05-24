using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBLLibrary
{
    public interface IAdmin<T,K>
    {
        ICollection<T> GetUsers();
        T GetUser(K id);
    }
}
