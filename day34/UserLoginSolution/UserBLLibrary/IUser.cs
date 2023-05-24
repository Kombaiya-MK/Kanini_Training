using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBLLibrary
{
    public interface IUser <T,K>
    {
        T GetUser(K id);
    }
}
