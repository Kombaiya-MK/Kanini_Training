namespace DoctorFEApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Provider provider = new Provider();
            provider.start();
            //provider.Appointment();
        }
    }
}