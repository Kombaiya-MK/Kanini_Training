using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingTypesApp
{
    internal class Program
    {
        static int number1, number2;
        private static object console;

        static void TakeTwoNumbers()
        {
            Console.WriteLine("please enter the first number ");
            number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter the second number ");
            number2 = Convert.ToInt32(Console.ReadLine());
        }
        private static void add()
        {
            int sum = number1 + number2;
            Console.WriteLine("The sum of {0} and {1} is {2} ", number1, number2, sum);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            TakeTwoNumbers();
            add();
            //Console.WriteLine("Please Enter your name");
            //string username = Console.ReadLine();
            //Console.WriteLine("Welcome " +  username);
            //Console.WriteLine("Welcome {0} ",username);
            //Console.WriteLine("Please Enter the first number ");
            //int number1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Please Enter the second number ");
            //int number2 = Int32.Parse(Console.ReadLine());
            //int sum = number1 + number2;
            //Console.WriteLine("The sum of {0} and {1} is {2} ",number1,number2,sum);
            //Console.ReadKey();
        }
    }
}
