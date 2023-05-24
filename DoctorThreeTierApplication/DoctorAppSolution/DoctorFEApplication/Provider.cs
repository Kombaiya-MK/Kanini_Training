using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DoctorBLLibrary;
using DoctorDALLibrary;
using DoctorModelLibrary;

namespace DoctorFEApplication
{
    internal class Provider
    {
        DoctorRepository doctorRepository;
        IBookAppointment ManageAppointment;
        public Provider() 
        {
            doctorRepository = new DoctorRepository();
            InitializeClinic();
            ManageAppointment = new ManageAppointments(doctorRepository);

        }

        private void InitializeClinic()
        {
            int choice = 0;
            do
            {

                Doctor obj = new Doctor();
                obj.GetDoctorDetails();
                bool result;
                doctorRepository.Add(obj, out result);
                //Doctor[] doc = doctorRepository.GetAll();
                //for(int i = 0;i < doc.Length;i++)
                //{
                //    Console.WriteLine(doc[i]);
                //}

                if (result)
                    Console.WriteLine("The doctor info added successfully");
                else
                    Console.WriteLine("Insertion Failed");
                Console.WriteLine("Do you want to add more doctor info?");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Enter either 0 or 1");
                }

            } while (choice != 0);
        }


            void printMenu()
            {
                Console.WriteLine("1.Show Doctors");
                Console.WriteLine("2.Book Appointment");
                Console.WriteLine("3.Show Appointments");
                Console.WriteLine("0.Exit");

            }

            public void InteractWithStore()
            {
                int choice = 0;
                printMenu();
                Console.WriteLine("Enter Choice : ");
                choice = int.Parse(Console.ReadLine());
                while (choice != 0)
                {
                    
                        switch(choice)
                        {
                            case 0: Console.WriteLine("Thank you and take care of your health");
                                break;
                            case 1:
                                Console.WriteLine("Available doctors in the clinic : ");
                                printDoctors();
                                break;
                            case 2: Console.WriteLine("Book Appointment");
                                BookAppointment();
                                break;
                            case 3: Console.WriteLine("Appointments");
                                ShowAppointments();
                                break;
                            default: Console.WriteLine("Enter valid choice");
                                break;


                        }
                    Console.WriteLine("Enter Choice : ");
                    choice = int.Parse(Console.ReadLine());
            } 
                //printMenu();
            }


        private void ShowAppointments()
        {
           ManageAppointment.ShowAppointments();
        }

        private void BookAppointment()
        {
            Console.WriteLine("Enter doctor id and slot to book appointment");
            Console.Write("Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("slot number : ");
            int slot = Convert.ToInt32(Console.ReadLine());
            doctorRepository.Get(id);
            //Console.WriteLine(doctor);
            Console.WriteLine(doctorRepository.Get(id));
            bool result = false;
            ManageAppointment.BookAppointment(doctorRepository.Get(id), slot, out result);
            if (result) 
                Console.WriteLine("Booking confirmed");
            else 
                Console.WriteLine("Booking failed");
        }

        

        private void printDoctors()
        {
            Doctor[] doctors = doctorRepository.GetAll();
            for (int i = 0; i < doctors.Length; i++)
            {
                Console.WriteLine(doctors[i]);
            }

            ManageAppointment.ShowDoctors();
        }
    }
}
