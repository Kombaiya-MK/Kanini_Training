using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace doctorModelLibrary
{
    public class Patient
    {
        public int pid { get; set; }
        public string name { get; set; }
        public int age;
        public string phone { get; set; }
        //public const string motif = @"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$";

        public Patient() { }
        public Patient(int id, string name, int age, string phone)
        {
            pid = id;
            this.name = name;
            this.age = age;
            this.phone = phone;
        }

        public void TakePatientDetails()
        {
            string? number = "";
            Console.WriteLine("------Enter patient info-------");
            Console.Write("Enter name : ");
            name = Console.ReadLine();
            Console.Write("Enter age : ");
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Enter a valid age ");
            }
            //age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter phone number :");
            number = Console.ReadLine();
            if (number.Length != 10)
                //if (phone != null && Regex.Match(number, @"^(\+[0-9]{9})$").Success)
                //    phone = number;
                Console.WriteLine("Enter valid phone number");
            else
                phone = number;
            
        }

        public override string ToString()
        {
            string message = "";
            message += $"\nId : {pid}";
            message += $"\nName : {name}";
            message += $"\nAge : {age}";
            message += $"\nPhone number : {phone}";
            return message;
        }
    }
}
