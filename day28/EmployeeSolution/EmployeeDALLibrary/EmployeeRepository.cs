using System.Net.Http.Headers;
using EmployeeModelLibrary;
namespace EmployeeDALLibrary
{
    public class EmployeeRepository : IRepo<Employee , int>
    {
        public IDictionary<int, Employee> Employee;
        public EmployeeRepository() 

        { 
            Employee = new Dictionary<int, Employee>();
        }
        public void Add(Employee item)
        {
            //status = false;
            Employee.Add(item.Id, item);
            //return status;
        }

        public bool Delete(int id)
        {
            bool status = false;
            if(Employee.ContainsKey(id)) 
            {   
                Employee.Remove(id);
                status = true;
            }
            return status;
        }

        public Employee Get(int name)
        {
            if(Employee.ContainsKey(name))
            {
                return Employee[name];
            }
            //else
            //{
            //    throw new NoValueAvailableException();
            //}
            return null;
        }

        public ICollection<Employee> GetAll()
        {
           return Employee.Values;
        }

        public bool Update(Employee item)
        {
            bool status = false;
            if( Employee.ContainsKey(item.Id) )
            {
                Employee[item.Id] = item;
                status = true;
            }
            return status;
        }
    }

}