using EmployeeDALLibrary;
using EmployeeModelLibrary;
using System.ComponentModel;

namespace EmployeeBALibrary
{
    public class EmployeeManage
    {
        private readonly IRepo< Employee, int> _repo;
        public EmployeeManage()
        {

        }
        public EmployeeManage(IRepo<Employee, int> repo)
        {
            _repo = repo;

        }
        public Employee Add(Employee employee)
        {
            return _repo.Add(employee); 
        }
        public ICollection<Employee> GetAll()
        {
            return _repo.GetAll();
        }
        public List<Employee> SortEmployee()
        {
            return _repo.SortSalaryEmployee();
        }

        public List<Employee> FindEmployees()
        {
            return _repo.EmployeeDetails();
        }
        

    }
}