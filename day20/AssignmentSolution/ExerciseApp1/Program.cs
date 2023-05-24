namespace ExerciseApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of the program");
            MathOperations obj = new MathOperations();
            obj.TakeNumbers();
            obj.PrintResult();
            Console.ReadKey();
        }
    }
}