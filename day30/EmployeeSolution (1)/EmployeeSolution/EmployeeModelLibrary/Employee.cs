namespace EmployeeModelLibrary
{
    public class Employee : IComparable<Employee>
    {
        public int Id { get => id; set => id = value; }
        public int Age { get => age; set => age = value; }
        public string Name { get => name; set => name = value; }
        public double Salary { get => salary; set => salary = value; }

        int id, age;
        string name;
        double salary;
        public Employee()
        {
        }
        public Employee(int id, int age, string name, double salary)
        {
            this.id = id;
            this.age = age;
            this.name = name;
            this.salary = salary;
        }
        public void TakeEmployeeDetailsFromUser()
        {
            Console.WriteLine("Enter the ID : ");
            int TempID;
            while (!int.TryParse(Console.ReadLine(), out TempID))
            {
                Console.WriteLine("Please Enter valid Id .");
            }
            Id = TempID;

            Console.WriteLine("Enter the Name : ");
            string name = Console.ReadLine();
            Name = name;

            Console.WriteLine("Enter the Age : ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Please Enter valid Age .");
            }
            Age = age;

            Console.WriteLine("Enter the Salary : ");
            double salary;
            while (!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Please Enter valid Salary .");
            }
            Salary = salary;
        }
        public override string ToString()
        {
            return "Employee ID : " + id + "\nName: " + name + "\nAge: " + age +
            "\nSalary:" + salary;
        }
        public int CompareTo(Employee? other)
        {
            return this.Salary.CompareTo(other.Salary);
        }

    }
}