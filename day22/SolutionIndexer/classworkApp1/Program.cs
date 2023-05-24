namespace classworkApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int? number = null;
            //int? number1 = 100;
            //Console.WriteLine(number);
            //int number2 =  number ?? 0;
            //int number3 = number ?? 0;
            //Console.WriteLine(++number2);
            Console.WriteLine("Hello, World!"); 
            int Max = int.MaxValue;
            checked //Block that is used to stop the cycle 
            {
                ++Max;
            }
            Console.WriteLine(++Max);
        }
    }
}