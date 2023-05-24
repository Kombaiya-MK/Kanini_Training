using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorBLLibrary
{
    public interface IAdmin<T,S,A,K>
    {
        T[] ShowDoctors();
        S[] ShowPatients();
        A[] ShowAppointments();
        T GetDoctor(K id);
        bool AddDoctors(T item);
        bool RemoveDoctors(K id);
        bool RemovePatients(K id);
        bool RemoveAppointments(K id);

    }
}
