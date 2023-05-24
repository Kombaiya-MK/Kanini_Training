namespace EmployeeFEApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Provider provider = new Provider();
            provider.AddEmployees();
            //provider.ShowEmployees();
            provider.EmployeePromotion();
            //provider.Medium();
            //Console.WriteLine("Hello, World!");
            //provider.InteractWithApp();
        }
    }
}