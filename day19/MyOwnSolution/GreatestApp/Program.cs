using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestApp
{
    internal class Program
    {
        static double number1, number2, number3;

        private static void GetNumbers()
        {
            Console.WriteLine("Enter the first number : ");
            number1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the Second number : ");
            number2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the third number : ");
            number3 = Convert.ToDouble(Console.ReadLine());
        }
        private static void GreatestOfThree()
        {
            if (number1 < number2) 
            {
                if (number2 > number3)
                {
                    Console.WriteLine("The greatest number out of three numbers is {0}" , number2);
                }
                else
                {
                    Console.WriteLine("The greatest number out of three numbers is {0}", number3);
                }
            }
            else
            {
                Console.WriteLine("The greatest number out of three numbers is {0}", number1);
            }
        }
        private static void GreatestOfThreeUsingTernaryOperator()
        {
            double result = (number1 >= number2 && number1 >= number2) ? number1 : (number2 >= number3 ? number2 :number3);
            Console.WriteLine("The greatest number out of three numbers is {0}", result);
        }
        static void Main(string[] args)
        {
            GetNumbers();
            GreatestOfThree();
            GreatestOfThreeUsingTernaryOperator();
            Console.ReadKey();

        }

       
    }
}
