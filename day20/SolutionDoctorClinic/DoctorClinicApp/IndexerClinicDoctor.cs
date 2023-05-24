using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicApp
{
    internal class IndexerClinicDoctor
    {
        IndexerDoctor[] doctors;

        public IndexerDoctor this[int index]
        {
            get { return doctors[index]; }
            set { doctors[index] = value; }
        }
        public void AddDoctors()
        {
            Console.Write("Enter Number of Doctors info that are needed to be added ? ");
            int counter = Convert.ToInt32(Console.ReadLine());
            if (counter <= 0) 
            {
                Console.WriteLine("The Number is Invalid..");
                Console.ReadKey();
                return;
            }
            doctors = new IndexerDoctor[counter];
        }
        public void PrintDoctors()
        {
            for (int i = 0; i < doctors.Length; i++)
            {
                doctors[i] = new IndexerDoctor();
                doctors[i].GetDoctorDetails(101 + i);
            }
            for (int i = 0; i < doctors.Length; i++)
            {
                doctors[i].ShowDoctorDetails(doctors[i]);
            }
        }
    }
}
