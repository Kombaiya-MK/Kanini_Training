using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicApp
{
    internal class ClinicDoctor : Doctor
    {
        public Doctor IncludeDoctor()
        {
            Doctor d1 = new Doctor();
            d1.GetDoctorDetails();
            return d1;
        }
        public void PrintDoctorDetails(Doctor d2)
        {
            ShowDoctorDetails(d2);
        }
    }
}
