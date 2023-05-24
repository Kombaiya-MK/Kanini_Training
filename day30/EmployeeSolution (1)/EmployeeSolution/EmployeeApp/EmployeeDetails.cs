using EmployeeBALibrary;
using EmployeeDALLibrary;
using EmployeeModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    internal class EmployeeDetails 
    {
        List<string> PromotionList=new List<string>();

        EmployeeManage manage;
        IRepo<Employee, int> employeeRepo;
        public EmployeeDetails() 
        {
            employeeRepo = new EmployeeDAL();
            manage =new EmployeeManage(employeeRepo);//Dependency Injection
        }
        void EmployeePromotionList()
        {
            Console.WriteLine("Enter Employee promotion order list, enter blank to stop");
            string name = Console.ReadLine();
            while (!String.IsNullOrEmpty(name))
            {
                PromotionList.Add(name);
                name = Console.ReadLine();
            }
            Console.WriteLine("Employess promotion order ");
            foreach (string item in PromotionList)
            {
                Console.WriteLine(item);
            }
        }
        void EmployeePosition()
        {
            Console.WriteLine("Enter the name of the employee to who's position you want to know ");
            string name = Console.ReadLine();
            Console.WriteLine(name + " is in the position " + (PromotionList.IndexOf(name) + 1));

        }
        public void RemoveExcessMemory()
        {
            Console.WriteLine("Size of the promotion list" + PromotionList.Capacity);
            PromotionList.TrimExcess();
            int size = PromotionList.Capacity;
            Console.WriteLine("After getting rid of excess data :" + size);
        }
        public void SortedEmployeeList()
        {
            SortedSet<string> Promotion = new SortedSet<string>();
            foreach (string str in PromotionList)
            {
                Promotion.Add(str);
            }
            Console.WriteLine("Sorted list");
            foreach (string name in Promotion)
            {
                Console.WriteLine(name);
            }

        }

        public void EasyExercise()
        {
            try
            {
                int PromoChoice = 0;
                do
                {
                    Console.WriteLine("1.Promotion List \n2.Employee Promotion Position \n3.Show Capacity \n4.Employees in sorted order");
                    Console.WriteLine("Select the Option.....");
                    PromoChoice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("*********************************************");
                    switch (PromoChoice)
                    {
                        case 1:
                            EmployeePromotionList();
                            break;
                        case 2:
                            EmployeePosition();
                            break;
                        case 3:
                            RemoveExcessMemory();
                            break;
                        case 4:
                            SortedEmployeeList();
                            break;
                        case 0:
                            Console.WriteLine("Invalid Entry ");
                            break;
                    }
                } while (PromoChoice != 0);
            }
            catch
            {

            }
        }

        public void MediumExercise()
        {

            try
            {
                int choice = 0;
                do
                {
                    Console.WriteLine("1.Find Employee by ID \n2.Get Employees by their name \n3.Sort Employees based on their salary \n4.Find the Employees Who are Elders");
                    Console.WriteLine("Select the Option ...");
                    int.TryParse(Console.ReadLine(), out choice);
                    Console.WriteLine("*********************************************");
                    switch(choice)
                    {
                        case 1:
                            var employeesUsingID = manage.FindEmployees();
                            Console.WriteLine("Enter the ID of the employee to display");
                            int id = Convert.ToInt32(Console.ReadLine());
                            var MatchedEmployee = from emp in employeesUsingID
                                                  where emp.Id == id
                                                  select emp;
                            foreach (var i in MatchedEmployee)
                                Console.WriteLine(i);
                            break;

                        case 2:
                            var employeesUsingName = manage.FindEmployees();
                            Console.WriteLine("Enter the Name of the employee to display");
                            string Username = Console.ReadLine();
                            var MatchedEmployee2 = from emp in employeesUsingName
                                                   where emp.Name == Username
                                                   select emp;
                            foreach (var i in MatchedEmployee2)
                                Console.WriteLine(i);
                            break;
                        case 3:
                            var empSalary = manage.SortEmployee().ToList();
                            if (empSalary.Count > 0)
                            {
                                foreach (var item in empSalary)
                                {
                                    Console.WriteLine(item);
                                    Console.WriteLine("----------------------------------------");
                                }
                            }
                            break;
                        case 4:
                            var Elderemployees = manage.FindEmployees();
                            Console.WriteLine("Enter the age :");
                            int UserAge = Convert.ToInt32(Console.ReadLine());
                            var MatchedEmployee3 = from emp in Elderemployees
                                                   where emp.Age >= UserAge
                                                   select emp;
                            foreach (var i in MatchedEmployee3)
                                Console.WriteLine(i);
                            break;


                    }
                } while (choice != 0);
            }
            catch { }
        }


        public void Application()
        {
            try
            {
                int choice = 0;
                do
                {
                    Console.WriteLine("1.Add Employee Details \n2.Print Employee Details");
                    Console.WriteLine("Select the Option ...");
                    int.TryParse(Console.ReadLine(), out choice);
                    Console.WriteLine("*********************************************");

                    switch (choice)
                    {
                        case 0: Console.WriteLine();
                            break;
                        case 1:
                            string NameChoice = "";
                            do
                            {
                                Employee employee = new Employee();
                                employee.TakeEmployeeDetailsFromUser();
                                if (employee.Name != "")
                                    manage.Add(employee);

                            } while (NameChoice != "");
                            break;

                        case 2:
                            var employees = manage.GetAll().ToList();
                            if (employees.Count > 0)
                            {
                                foreach (var item in employees)
                                {
                                    Console.WriteLine(item);
                                    Console.WriteLine("----------------------------------------");
                                }
                            }
                            break;
                    }
                } while (choice != 0);
            }
            catch { }
        }
        //public void EmployeeList()
        //{
        //    try
        //    {
        //        int choice = 0;
        //        do
        //        {
        //            StartMenu();
        //            Console.WriteLine("Select the Option ...");
        //            int.TryParse(Console.ReadLine(), out choice);
        //            Console.WriteLine("*********************************************");
                    
        //            switch (choice)
        //            {
        //                case 1:
        //                    string NameChoice = "";
        //                    do
        //                    {
        //                        Employee employee = new Employee();
        //                        employee.TakeEmployeeDetailsFromUser();
        //                        if (employee.Name != "")
        //                            manage.Add(employee);

        //                    } while (NameChoice != "");
        //                    break;

        //                case 2:
        //                    var employees = manage.GetAll().ToList();
        //                    if (employees.Count>0)
        //                    {
        //                        foreach (var item in employees)
        //                        {
        //                            Console.WriteLine(item);
        //                            Console.WriteLine("----------------------------------------");
        //                        }
        //                    }
        //                    break;
        //                case 3:
        //                    var empSalary = manage.SortEmployee().ToList();
        //                    if (empSalary.Count > 0)
        //                    {
        //                        foreach (var item in empSalary)
        //                        {
        //                            Console.WriteLine(item);
        //                            Console.WriteLine("----------------------------------------");
        //                        }
        //                    }
        //                    break;

        //                case 4:
        //                    var employeesUsingID = manage.FindEmployees();
        //                    Console.WriteLine("Enter the ID of the employee to display");
        //                    int id = Convert.ToInt32(Console.ReadLine());
        //                    var MatchedEmployee= from emp in employeesUsingID
        //                                         where emp.Id == id
        //                                         select emp;
        //                    foreach(var i in MatchedEmployee)
        //                        Console.WriteLine(i);
        //                    break;

        //                case 5:
        //                    var employeesUsingName = manage.FindEmployees();
        //                    Console.WriteLine("Enter the Name of the employee to display");
        //                    string Username = Console.ReadLine();
        //                    var MatchedEmployee2 = from emp in employeesUsingName
        //                                          where emp.Name == Username
        //                                          select emp;
        //                    foreach (var i in MatchedEmployee2)
        //                        Console.WriteLine(i);
        //                    break;

        //                case 6:
        //                    var Elderemployees = manage.FindEmployees();
        //                    Console.WriteLine("Enter the age :");
        //                    int UserAge = Convert.ToInt32(Console.ReadLine());
        //                    var MatchedEmployee3 = from emp in Elderemployees
        //                                           where emp.Age >= UserAge
        //                                           select emp;
        //                    foreach (var i in MatchedEmployee3)
        //                        Console.WriteLine(i);
        //                    break;
                         
        //                case 7:
                            
        //                    int PromoChoice = 0;
        //                    do
        //                    {
        //                        PromotiontMenu();
        //                        Console.WriteLine("Select the Option.....");
        //                        int.TryParse(Console.ReadLine(), out PromoChoice);
        //                        Console.WriteLine("*********************************************");
        //                        switch(PromoChoice)
        //                        {
        //                            case 1:
        //                                EmployeePromotionList();
        //                                break;
        //                            case 2:
        //                                EmployeePosition();
        //                                break;
        //                            case 3:
        //                                RemoveExcessMemory();
        //                                break;
        //                            case 4:
        //                                SortedEmployeeList();
        //                                break;
        //                            case 0:
        //                                Console.WriteLine("Invalid Entry ");
        //                                break;
        //                        }
        //                    } while (PromoChoice != 0);
        //                    break;
        //                case 0:
        //                    Console.WriteLine();
        //                    break;
        //            }

        //        } while (choice!=0);

        //    }
        //    catch
        //    {

        //    }
        //}

    }
}

