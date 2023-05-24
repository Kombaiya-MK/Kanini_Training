using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using doctorModelLibrary;
namespace doctorClinicOverriding
{
    internal class ClinicDoctor
    {
        doctor[] doctors;
        public int counter { get; set; }
        public doctor this[int index]
        {
            get { return doctors[index]; }
            set { doctors[index] = value; }
        }

        public doctor this[string name]
        {
            get { 
                foreach(doctor obj in doctors)
                {
                    if (obj.Doc_name.ToLower() == name.ToLower())
                    {
                        return obj;
                    }
                }
                Console.WriteLine("Doctor name is invalid!");
                return new doctor();
                
                }
            
        }
        public void AddDoctors()
        {
            Console.Write("Enter Number of Doctors info that are needed to be added ? ");
            counter = Convert.ToInt32(Console.ReadLine());
            if (counter <= 0)
            {
                Console.WriteLine("The Number is Invalid..");
            }
            doctors = new doctor[counter];
        }
        public void PrintDoctors()
        {
            for (int i = 0; i < doctors.Length; i++)
            {
                doctors[i] = new doctor();
                doctors[i].GetDoctorDetails(101 + i);
            }
            for (int i = 0; i < doctors.Length; i++)
            {
                doctors[i].ShowDoctorDetails(doctors[i]);
            }
        }


        public void CompareDoctors()
        {
            Console.WriteLine("Enter doctor info compare ..");
            doctor doc1 = new doctor();
            doctor doc2 = new doctor();
            doc1.GetDoctorDetails(101);
            doc2.GetDoctorDetails(102);
            if (doc1 == doc2)
            {
                Console.WriteLine($"Both Doctors {doc1.Doc_name} and {doc2.Doc_name}  have same years of experience in same field.");
            }
            else
            {
                Console.WriteLine($"Both Doctors {doc1.Doc_name} and {doc2.Doc_name}  don't have same years of experience or from same field.");
            }
        }

        public void removeDoctors(doctor d1)
        {
            doctors = doctors.Where(e => e != d1).ToArray();
        }

    }
}
