namespace DoctorFEApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the clinic");
            Provider obj = new Provider();
            obj.InteractWithStore();
        }
    }
}