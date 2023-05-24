using PizzaModelLibrary;
namespace ObjectOrientationAPP
{
    internal class Program
    {
        static void Banking(ICustomerManager manager)
        {
            manager.ApproveLoan();
            manager.SolveProblem();
            //manager.
        }

        static void CustomerBanking(ICustomerManager manager)
        {
            manager.ApproveLoan();
            manager.SolveProblem();

        }
        static void EmployeeWork(IEmployeeManager manager)
        {
            manager.ConductMeetings();
            manager.AssignWork();
        }

        static void BankOperation(IBanking banking)
        {
            banking.ConductMeetings();
            banking.AssignWork();
            banking.SolveProblem();
        }
        static void Main(string[] args)
        {
            //Pizza pizza = new Pizza(433.25f , "Cheese Pizza" ,101);
            //Console.WriteLine(pizza);


            //Pizza pizza = new Pizza(233.4f,"ABC",101);
            //Console.WriteLine(pizza);
            Manager manager = new BranchManager();
            //CustomerBanking(manager);
            //EmployeeWork(manager);
            BankOperation(manager);
            Console.WriteLine("Hello, World!");
        }
    }
}