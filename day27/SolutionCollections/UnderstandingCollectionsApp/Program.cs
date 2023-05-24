using System.Collections;
using System.Reflection;

namespace UnderstandingCollectionsApp
{
    internal partial class Program
    {
        
        void UnderstandingCollections() 
        {
            ArrayList list = new ArrayList();
            list.Add(100);
            list.Add(500.67);
            list.Add("234");
            list.Add("28781.87");
            double sum = 0;
            foreach (object i in list)
            {
                double number = double.Parse(i.ToString());
                sum+= number;
            }
            Console.WriteLine(sum);
        }

        void UnderstandingGenericCollections() //Because Generic is Type safe
        {
            List<double> list = new List<double>();
            list.Add(100);
            list.Add(500.67);
            list.Add(234.5f);
            list.Add(28781.87);
            //double x = Convert.ToDouble(Console.ReadLine());
            //list.Add(x);
            double sum = 0;
            foreach (double number in list)
            {
                //double number = double.Parse(i.ToString());
                sum += number;
            }
            Console.WriteLine(sum);
            Console.WriteLine($"The length of the list : {list.Count}");
            list.Remove(100);
            Console.WriteLine($"After Removal the size of the list {list.Count}");
            list.Add(1234);
            Console.WriteLine($"The length of the list after updation : {list.Count}");
            Console.WriteLine($"The capacity of the list {list.Capacity}");
            list.Add(567);
            Console.WriteLine($"The capacity after updation {list.Capacity}");
        }

        void UnderstandingHashSet()
        {
            HashSet<string> names = new HashSet<string>()
            { 
                "Naruto" , "Eren Jaeger" , "Mikasa Ackerman" , "Johan Liebert" , "Naruto"
            };

            HashSet<object> list = new HashSet<object>()
            { 
                1,"Mk",22
            };


            HashSet<IList<int>> list2 = new HashSet<IList<int>>();
            IList<int> l1 = new List<int>() { -1,-1,2};
            IList<int> l2 = new List<int>() { -1, -1, 2 };
            list2.Add(l1);
            list2.Add(l2);
            Console.WriteLine(list2.Count);

            //foreach (string name in names)
            //{
            //    Console.WriteLine(name);
            //}

            //foreach(var obj in list)
            //{
            //    Console.WriteLine(obj);
            //}
        }

        void UnderstandingSortedSet()
        {
            SortedSet<string> names = new SortedSet<string>();
            names.Add("Kishore");
            names.Add("GayKishore");
            names.Add("KKishore");
            names.Add("GKishore");
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }

        }


        void UnderstandingCustomList()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee());
            //Console.WriteLine(1 == 1);
            employees[0].Name = "Kishore";
            employees[0].Id = 1;
            employees[0].Gender = "Male";
            //employees.Add(employees[0]);
            employees.Add(new Employee(2,"Gayshore" , "Male"));
            employees.Add(new Employee { Id = 3, Name = "Naruto", Gender = "Male" });
            employees.Sort(new SortByID());
            foreach(Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
            Employee e = new Employee(2, "Gayshore", "Male");
            Console.WriteLine($"If the employees list contains the object e : {employees.Contains(e)}");
        }

        void UnderstandingSortedSetCustomTypes()
        {
            SortedSet<Employee> employees = new SortedSet<Employee>();
            Employee e = new Employee();
            //Console.WriteLine(1 == 1);
            e.Name = "Kishore";
            e.Id = 1;
            e.Gender = "Male";
            employees.Add(e);
            //employees.Add(employees[0]);
            employees.Add(new Employee(2, "Gayshore", "Male"));
            employees.Add(new Employee { Id = 3, Name = "Naruto", Gender = "Male" });
            //employees.S
            foreach(Employee employee in employees) {  Console.WriteLine(employee); }


        }
        static void Main(string[] args)
        {
            int a = 0;
            Console.WriteLine("Hello, World!");
            // new Program().sample();
            //new Program().UnderstandingCollections();
            new Program().UnderstandingGenericCollections();
            //new Program().UnderstandingHashSet();
            //new Program().UnderstandingSortedSet();
            // new Program().UnderstandingCustomList();
            //new Program().UnderstandingSortedSetCustomTypes();
            // Console.WriteLine(a);
        }
    }
}