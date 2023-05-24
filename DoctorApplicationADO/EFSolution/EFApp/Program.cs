
using EFSampleApp;

namespace EFApp
{
    public class Program    {
        CinemaContext context = new CinemaContext();
        public void AddCustomer()
        {
            Customer customer = new Customer(){ Name = "Hinata" , Age = 22 , Phone = "9876543210"};
            context.Customers.Add(customer);
            context.SaveChanges();

        }

        public void UpdateCustomers()
        {
            Customer customer = context.Customers.SingleOrDefault(c => c.Id == 101);
            Console.WriteLine("After get" + context.Entry(customer).State);
            Console.WriteLine("Please enter the new name");
            customer.Name = Console.ReadLine();
            Console.WriteLine("After edit " + context.Entry(customer).State);
            context.SaveChanges();
            Console.WriteLine("After save chanegs " + context.Entry(customer).State);
            Console.WriteLine("Updated");
        }
        public void printCustomers()
        {
            var customers = context.Customers;
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }

        public void DeleteCustomers()
        {

            Customer customer = context.Customers.SingleOrDefault(c => c.Id == 103);
            Console.WriteLine("After get " + context.Entry(customer).State);
            context.Customers.Remove(customer);
            Console.WriteLine("After remove" + context.Entry(customer).State);
            context.SaveChanges();
            Console.WriteLine("After save chanegs " + context.Entry(customer).State);
            Console.WriteLine("Deleted");
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.AddCustomer();
            program.UpdateCustomers();
            program.printCustomers();
            program.DeleteCustomers();
            program.printCustomers();
            Console.WriteLine("Hello, World!");
        }
    }
}