using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLLibrary
{
    public interface IEmployee<T,K>
    {
        void AddEmployees(T item);
        void ShowEmployees();
    }
}
