using EmployeeModelLibrary;

namespace EmployeeDALLibrary
{
    public class EmployeeDAL : IRepo<Employee,int> 
    {
        IDictionary<int, Employee> employees = new Dictionary<int, Employee>();
        
        List<Employee> EmployeesList =new List<Employee>();
       
        public Employee Add(Employee item)
        {
            EmployeesList.Add(item);
            employees.Add(item.Id, item);
            return item;
        }

        public ICollection<Employee> GetAll()
        {
            return employees.Values.ToList();
        }
     
        List<Employee> IRepo<Employee, int>.SortSalaryEmployee()
        {
            EmployeesList.Sort();
            return EmployeesList;
        }

        List<Employee> IRepo<Employee, int>.EmployeeDetails()
        {
            return EmployeesList;
        }

    }
}