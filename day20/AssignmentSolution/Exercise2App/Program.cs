using ExerciseApp2;

namespace Exercise2App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of the program");
            GreatestNumber obj = new GreatestNumber();
            obj.GetInput();
            obj.PrintMax();
            Console.ReadKey();
        }
    }
}