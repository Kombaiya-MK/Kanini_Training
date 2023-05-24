using System.IO.Pipes;
using System.Collections;

namespace ExerciseApp3
{
    internal class Program
    {
        int Number;
        List <int> Primes = new List<int>();

        public void GetInput()
        {
            int sum = 0;
            Console.Write("Enter Number : ");
            Number = Convert.ToInt32(Console.ReadLine());
            while (Number != 0) 
            {
                if (CheckPrime(Number) != 0)
                {
                    sum += CheckPrime(Number);
                    Primes.Add(Number);
                }

                Console.Write("Enter Number : ");
                Number = Convert.ToInt32(Console.ReadLine());

            }
            PrintOutput(Primes);

        }
        public int CheckPrime(int Number)
        {
            if (Number < 2) { return 0; }
            else if (Number == 2 || Number == 3 || Number == 5) { return Number; }
            else if (Number % 2 == 0 || Number % 3 == 0 || Number % 5 == 0) { return 0; }
            else
            {
                for(int i = 7; i < Math.Sqrt(Number); i+=4) 
                {
                    if (i % 2 != 0 || (i + 2) % 2 == 0)
                        return 0;
                }
            }
            return Number;
        }

        public void PrintOutput(List<int> primes)
        {
            Console.WriteLine($"The prime numbers are :");
            foreach (int i in primes)
            {
                Console.WriteLine(i);

            }
            
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            Program program = new Program();
            program.GetInput();
            //program.PrintOutput(primes);
        }
    }
}