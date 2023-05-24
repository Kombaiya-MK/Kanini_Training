using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicApp
{
    internal class Doctor
    {
        public int Doc_ID { get; set; }
        public string Doc_name { get; set; }
        public int Doc_Exp { get; set; }

        public void GetDoctorDetails()
        {
            Console.Write("Enter Doctor ID : ");
            Doc_ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Doctor Name : ");
            Doc_name = Console.ReadLine();
            Console.Write("Enter Doctor Experience : ");
            Doc_Exp = Convert.ToInt32(Console.ReadLine());

        }

        public void ShowDoctorDetails(Doctor d3)
        {
            Console.WriteLine("\nDoctor Information");
            Console.WriteLine("***********************************************");
            Console.WriteLine($"Doctor ID : {d3.Doc_ID}");
            Console.WriteLine($"Doctor Name : Dr.{d3.Doc_name}");
            Console.WriteLine($"Doctor Experience : {d3.Doc_Exp} Years");
            Console.WriteLine("***********************************************");
          


        }
    }
}
