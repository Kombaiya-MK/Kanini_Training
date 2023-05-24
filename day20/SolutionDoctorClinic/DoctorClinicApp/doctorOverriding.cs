using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicApp
{
    internal class doctorOverriding
    {
        public int Doc_ID { get; set; }
        public string? Doc_name { get; set; }
        public int Doc_Exp { get; set; }

        public string[,]? speciality;

        public doctorOverriding()
        {
            speciality = new string[5,5];
        }
        public doctorOverriding(int S_count)
        {
            speciality = new string[S_count,S_count];
        }
        public string this[int index]
        {
            get { return speciality[index,index]; }
            set { speciality[index,index] = value; }
        }

        private void GetDetails()
        {
            Console.Write("Enter Doctor Name : ");
            Doc_name = Console.ReadLine();
            //Console.Write("Enter Doctor Experience : ");
            //Doc_Exp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Enter the Number of Specialities of Doctor {Doc_name}");
            int specility_count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < specility_count; i++)
            {
                Console.Write($"Enter Skill {i+1} : ");
                speciality[i,0] = Console.ReadLine();
                Console.Write($"Enter Experience {i + 1} : ");
                speciality[i,1] = Console.ReadLine();
            }
        }
        public void GetDoctorDetails()
        {
            Console.Write("Enter Doctor ID : ");
            Doc_ID = Convert.ToInt32(Console.ReadLine());
            GetDetails();

        }
        public void GetDoctorDetails(int ID)
        {
            Doc_ID = ID;
            GetDetails();
        }

        public void ShowDoctorDetails(doctorOverriding d3)
        {
            Console.WriteLine("\nDoctor Information");
            Console.WriteLine("***********************************************");
            Console.WriteLine($"Doctor ID : {d3.Doc_ID}");
            Console.WriteLine($"Doctor Name : Dr.{d3.Doc_name}");
            Console.WriteLine($"Doctor Experience : {d3.Doc_Exp} Years");
            Console.WriteLine($"Skills of Doctor {Doc_ID} is : ");
            int count = 0;
            while (speciality[count , count] != null)
            {
                Console.WriteLine($"{count + 1} . {speciality[count,0]} \t {speciality[count, 1]}");
                count ++;
            }
            Console.WriteLine("***********************************************");



        }
    }
}
