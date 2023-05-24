using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorBLLibrary
{
    public interface IPatient<T,S,A,K>
    {
        //void GetPatientDetails(K id);
        bool AddPatient(S patient);
        S GetPatient(K id);
        A GetAppointment(K id);
        T[] ShowDoctors();
        bool CheckPatient(K id);

    }
}
