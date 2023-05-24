using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorBLLibrary
{
    public interface IAppointment<T , S , A ,K>
    {
        A GetAppointment(K id);
        A[] ShowAppointments();
        bool RemoveAppointments(K id);
        bool AddAppointments(A item);
    }
}
