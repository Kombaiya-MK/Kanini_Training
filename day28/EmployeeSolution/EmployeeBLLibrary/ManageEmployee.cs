using EmployeeDALLibrary;
using EmployeeModelLibrary;
namespace EmployeeBLLibrary
{
    public class ManageEmployee : IEmployee<Employee , int>
    {
        IRepo<Employee, int> _repo;
        public ManageEmployee(IRepo<Employee, int> repo)
        {
            _repo = repo;
        }

        public void AddEmployees(Employee item)
        {
            //bool status = false;
            _repo.Add(item);
            //return status;
        }

        public void ShowEmployees()
        {
            var values = _repo.GetAll();
            foreach (var item in values) 
            {
                Console.WriteLine(item);
            }
        }

        public void GetEmployee(int id)
        {
            Console.WriteLine(_repo.Get(id));
        }

        public void ShowEmployeeNames()
        {
            var values = _repo.GetAll();
            foreach(var item in values)
            {
                Console.WriteLine(item.Name);
            }
        }
        public int GetIndex(string name)
        {
            int count = 0;
            var values = _repo.GetAll();
            foreach (var item in values)
            {
                count++;
                if (item.Name == name)
                    return count;
            }
            return 0;
        }
        public int GetCapacity()
        {
            Console.WriteLine($"The size of the list is {_repo.GetAll().Count}");
            return _repo.GetAll().ToList().Capacity;
        }

        public void SortNamesInAscending()
        {
            var values = _repo.GetAll();
            List<string> names = new List<string>();
            foreach(var item in values)
            {
                names.Add(item.Name);
            }
            names.Sort();
            Console.WriteLine("Names in the sorted order");
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }

        public void SortBySalary()
        {
            var values = _repo.GetAll();
            var result = from emp in values orderby emp.Salary select emp;
            Console.WriteLine("Employees sorted by salary");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }    
        }

        public void GetEmployeesByName(string name)
        {
            var values = _repo.GetAll();
            var result = from emp in values where emp.Name == name select emp;
            Console.WriteLine($"Employees with the name of {name}");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public void GetOlderEmployees(int id)
        {
            var values = _repo.GetAll();
            int age = _repo.Get(id).Age;
            //var given_employee = from emp in values where emp.Name == name select emp;
            var result = from emp in values where emp.Age > age select emp;
            Console.WriteLine($"Employee's older than {_repo.Get(id).Name}");
            foreach ( var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public void updateEmployees(Employee employee) 
        {
            if (_repo.Update(employee))
                Console.WriteLine("Employee updated successfully");
            else 
                Console.WriteLine("Updation Failed!!");
        }

        public void deleteEmployees(int id) 
        {
            if (_repo.Delete(id))
                Console.WriteLine("Employee data deleted successfully");
            else
                Console.WriteLine("Deletion Failed!!");
        }
    }
        
}