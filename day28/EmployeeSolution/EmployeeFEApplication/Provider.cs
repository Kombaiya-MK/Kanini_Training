using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeBLLibrary;
using EmployeeDALLibrary;
using EmployeeModelLibrary;

namespace EmployeeFEApplication
{
    internal class Provider
    {
        IRepo<Employee , int> empRepo;
        ManageEmployee Manage;
        public Provider() 
        {
            empRepo = new EmployeeRepository();
            Manage = new ManageEmployee(empRepo);
            
        }

        public void AddEmployees()
        {
            int n = 1;
            Console.WriteLine("Enter Employee details by clicking 1");
            while (n != 0)
            {
                Employee emp = new Employee();
                emp.TakeEmployeeDetailsFromUser();
                Manage.AddEmployees(emp);
                Console.WriteLine("Do you want add more employees ?");
                n = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void ShowEmployees() 
        {
            Manage.ShowEmployees();
        }


        public void EmployeePromotion()
        {
            Console.WriteLine("Easy Exercise");
            Console.WriteLine("1.Show Promotion List \n2.Get Employee by Promotion order \n3.Show capacity \n4.Show Names in Ascending Order");
            int n = Convert.ToInt32(Console.ReadLine());
            do
            {
                
                if (n == 1)
                {
                    Manage.ShowEmployeeNames();
                }
                else if(n == 2)
                {
                    Console.WriteLine("Enter Name : ");
                    string name = Console.ReadLine();
                    if (Manage.GetIndex(name) == 0)
                        Console.WriteLine("Employee Not available");
                    else
                        Console.WriteLine($"{name} is at level {Manage.GetIndex(name)} in the promotion order");
                }
                else if (n == 3)
                {
                    Console.WriteLine($"The Capacity is {Manage.GetCapacity()}");
                    
                }
                else if(n == 4)
                {
                    Manage.SortNamesInAscending();
                }
                Console.WriteLine("1.Show Promotion List \n2.Get Employee by Promotion order \n3.Show capacity \n4.Show Names in Ascending Order");
                Console.WriteLine("Enter 0 to exit");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n != 0);
            
        }

        public void Medium()
        {
            Console.WriteLine("1.Get Employee by Id \n2.Sort Employee by salary \n3.Get employee with same name \n4.Employees older than given employee");
            int choice;
            do
            {
                Console.WriteLine("Enter Choice");
                choice = Convert.ToInt32(Console.ReadLine());
                
                if(choice == 1)
                {
                    Console.WriteLine("Enter Id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Manage.GetEmployee(id);
                }
                else if(choice == 2)
                {
                    Manage.SortBySalary();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter Name ");
                    string name = Console.ReadLine();
                    Manage.GetEmployeesByName(name);
                }
                else if(choice == 4)
                {
                    Console.WriteLine("Enter Id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Manage.GetOlderEmployees(id);
                }

            } while(choice != 0);
        }


        public void InteractWithApp()
        {
            //Console.WriteLine("**********************************************************");
            //Console.WriteLine("1.Add Employee \n2.Show Employees \n3.Update Employee \n4.Delete Employee ");
            //Console.WriteLine("******************************************************************");
            int choice;
            do
            {
                Console.WriteLine("**********************************************************");
                Console.WriteLine("1.Add Employee \n2.Show Employees \n3.Update Employee \n4.Delete Employee ");
                Console.WriteLine("******************************************************************");
                Console.WriteLine("Enter Choice");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Employee emp = new Employee();
                    emp.TakeEmployeeDetailsFromUser();
                    Manage.AddEmployees(emp);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Available Employees in the Organization");
                    Manage.ShowEmployees();
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter Employee details to be updates ");
                    Console.WriteLine("Enter Id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Employee emp = new Employee(id);
                    //emp.TakeEmployeeDetailsFromUser();
                    Manage.AddEmployees(emp);
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Enter Id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Manage.deleteEmployees(id);
                }

            } while (choice != 0);
        }
    }
}
