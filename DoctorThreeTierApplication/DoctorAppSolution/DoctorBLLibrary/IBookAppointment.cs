using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorModelLibrary;

namespace DoctorBLLibrary
{
    public interface IBookAppointment
    {
        bool BookAppointment(Doctor doctor, int slot ,out bool BookingStatus);
        Doctor[] ShowDoctors();
        void ShowAppointments();
    }
}
