using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicApp
{
    internal class ClinicDoctorUsingArray
    {
        Doctor[] doctors;

        public void AddDoctors()
        {
            Console.Write("Enter Number of Doctors info that are needed to be added ? ");
            int counter = Convert.ToInt32(Console.ReadLine());
            doctors = new Doctor[counter];
        }
        public void PrintDoctors() 
        {
            for (int i = 0; i < doctors.Length; i++)
            {
                doctors[i] = new Doctor();
                doctors[i].GetDoctorDetails();
            }
            for (int i = 0;i < doctors.Length; i++)
            {
                doctors[i].ShowDoctorDetails(doctors[i]);
            }
        }
    }
}
