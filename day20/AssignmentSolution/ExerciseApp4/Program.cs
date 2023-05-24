namespace ExerciseApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program to Find the length the username");
            StringLength user1 = new StringLength();
            user1.GetInput();
            user1.printLength();
            Console.ReadKey();
        }
    }
}