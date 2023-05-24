using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorBLLibrary;
using DoctorDALLibrary;
using doctorModelLibrary;

namespace DoctorFEApplication
{
    public class Provider
    {
        ManageClinic ManageClinic;
        IRepo<Doctor, int> _doc;
        IRepo<Patient, int> _patient;
        IRepo<Appointment, int> _appointment;
        public Provider()
        {
            _doc = new DoctorRepositoryADO();
            _patient = new PatientRepositoryADO();
            _appointment = new AppointmentRepositoryADO();
            ManageClinic = new ManageClinic(_doc , _patient , _appointment);
        }
        public void start()
        {
            int log;
            Console.WriteLine("Enter The Type of user \n1.Admin \n2.User \n(To Exit Press 0)");
            while (int.TryParse(Console.ReadLine(), out log))
            {
               
                switch (log)
                {
                    case 0:
                        Console.WriteLine("Thank you, take care of your health!!!");
                        break;
                    case 1: 
                        admin();
                        break;
                    case 2:
                        user();
                        break;
                    default:
                        Console.WriteLine("Enter valid choice!!!");
                        break;
                }
            }
        }

        public void admin() 
        {
            Console.WriteLine("Welcome !!!!");
            int choice;
            do
            {
                Console.WriteLine("1.Add Doctors \n2.Show Doctors \n3.Show Patients \n4.Show Appointments \n5.Remove Doctors \n6.Remove Patients \n7.Remove Appointments \n8.Get Doctor");
                Console.Write("Enter Operation : ");
                while(!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Enter Valid Choice!!!");
                }
                
                try
                {
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("Thank you!!! Bye Bye");
                            break;
                        case 1:
                            Doctor doc = new Doctor();
                            doc.GetDoctorsDetails();
                            if (ManageClinic.AddDoctors(doc))
                            {
                                Console.WriteLine("New doctor added successfully");
                            }
                            else
                            {
                                Console.WriteLine("Process Failed Successfully");
                            }
                            break;
                        case 2:
                            Console.WriteLine("\n---------------Doctor Details---------------");
                            foreach (var d in ManageClinic.ShowDoctors())
                            {
                                Console.WriteLine(d);
                            }
                            break;
                        case 3:
                            Console.WriteLine("--------------------Patient Details------------------");
                            foreach (var pat in ManageClinic.ShowPatients())
                            {
                                Console.WriteLine(pat);
                            }
                            break;

                        case 4:
                            Console.WriteLine("--------------------- Booked Appointments---------------");
                            foreach (var app in ManageClinic.ShowAppointments())
                            {
                                Console.WriteLine(app);
                            }
                            break;

                        case 5:
                            int id;
                            Console.WriteLine("Enter Id : ");
                            while(!int.TryParse(Console.ReadLine(), out id))
                            {
                                Console.WriteLine("Enter Valid Id");
                            }
                            if (ManageClinic.RemoveDoctors(id))
                                Console.WriteLine("Doctor data removed successfully");
                            else
                                Console.WriteLine("Deletion failed successfully");
                            break;
                        case 6:
                            int pid;
                            Console.WriteLine("Enter Id : ");
                            while (!int.TryParse(Console.ReadLine(), out pid))
                            {
                                Console.WriteLine("Enter Valid Id");
                            }
                            if (ManageClinic.RemovePatients(pid))
                                Console.WriteLine("Patient data removed successfully");
                            else
                                Console.WriteLine("Deletion failed successfully");
                            break;
                        case 7:
                            int Aid;
                            Console.WriteLine("Enter Id : ");
                            while (!int.TryParse(Console.ReadLine(), out Aid))
                            {
                                Console.WriteLine("Enter Valid Id");
                            }
                            if (ManageClinic.RemoveAppointments(Aid))
                                Console.WriteLine("Appointment removed successfully");
                            else
                                Console.WriteLine("Deletion failed successfully");
                            break;
                        case 8:
                            int did;
                            Console.WriteLine("Enter Id : ");
                            while (!int.TryParse(Console.ReadLine(), out did))
                            {
                                Console.WriteLine("Enter Valid Id");
                            }
                            Console.WriteLine(ManageClinic.GetDoctor(did));
                            break;  
                        default: 
                            Console.WriteLine("Enter valid Choice !!!");
                            break;

                    }
                }
                catch(NoValueException ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    Console.WriteLine("End of the Do - While !!!1");
                }
            } while (choice != 0);
        }

        public void user()
        {
            Console.WriteLine("New User or Already Existing User?");
            Console.WriteLine("\n1.New User \n2.Existing User");
            int user;
            Console.WriteLine("Enter user type : ");
            while (int.TryParse(Console.ReadLine(), out user))
            {
                if (user == 1)
                {
                    Patient pat = new Patient();
                    pat.TakePatientDetails();
                    ManageClinic.AddPatient(pat);
                    Console.WriteLine("Thank you for registering");
                }
                else if (user == 2)
                {
                    int id;
                    Console.Write("Enter patient id : ");
                    while (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("Enter Valid Id");
                    }

                    if (ManageClinic.CheckPatient(id))
                    {
                        Console.WriteLine("Welcome Back!!!");
                        Console.WriteLine(ManageClinic.GetPatient(id));
                        userfunc(id);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Id");
                    }
                }
            }
        }

        public void userfunc(int id)
        {
            int choice;
            do
            {
                Console.WriteLine("1.Show Doctors \n2.Show Appointments \n3.Book Appointments");
                while(!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Enter Valid Choice");
                }
                switch(choice)
                {
                    case 0: Console.WriteLine("Thank you!!");
                        break;
                    case 1: Console.WriteLine("Available doctors");
                        foreach(var doc in ManageClinic.ShowDoctors())
                        {
                            Console.WriteLine(doc);
                        }
                        
                    break;
                    case 2: Console.WriteLine("Appointments");
                        Console.WriteLine(ManageClinic.GetAppointment(id));   
                        break;
                    case 3:
                        Appointment appointment = new Appointment();
                        appointment.TakeAppointmentDetails();
                        ManageClinic.AddAppointments(appointment);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!!!");
                        break;
                }
            } while (choice != 0) ;
        }
        
    }
}
