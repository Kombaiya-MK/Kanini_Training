using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingCollectionsApp 
{
    public class Employee : IEquatable<Employee> , IComparable<Employee>
    {
        public int Id { get; set; }
        public string Name   { get; set; }
        public string Gender { get; set; }

        public Employee()
        { }
        public Employee(int id , string name , string gender)
        {
            Id = id;
            Name = name;
            Gender = gender;
        }

        public override string ToString()
        {
            string message = "";
            message += $"Id : {Id}";
            message += $"Name : {Name}";
            message += $"Gender : {Gender}";
            return message;
        }

        public bool Equals(Employee? gayshore)
        {
            //Employee e1, e2;
            //e1 = this;
            //e2 = other;

            //if (e1.Id == e2.Id)
            //    return true;
            //return false;     
            return this.Id == gayshore.Id;
        }

        public int CompareTo(Employee? other)
        {
            return 0-this.Name.CompareTo(other.Name);
        }
    }

    class SortByID : IComparer<Employee>
    {
        public int Compare(Employee? x, Employee? y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
}
