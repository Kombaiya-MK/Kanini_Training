using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp1
{
    internal class MathOperations
    {
        public double number1 { get; set; }
        public double number2 { get; set; }

        public void TakeNumbers()
        {
            Console.WriteLine("Enter Number 1 : ");
            number1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Number 2 : ");
            number2 = Convert.ToDouble(Console.ReadLine());
        }
        public double ToSum()
        {
            return number1 + number2;
         
        }
        public double ToMultiply()
        {
             
            return  number1 * number2;
        }
        public double ToSubtract()
        {
            return  number2 - number1;
            
        }
        
        public double ToDivide()
        {
            if (number2 == 0)
                Console.WriteLine("Divided by Zero exception");
            return number1 / number2;
            
        }
        public double ToModulo()
        {
            return number1 % number2;
            
        }
        public void PrintResult()
        {
            Console.WriteLine($"Sum of {number1} and {number2} is {ToSum()} ");
            Console.WriteLine($"Product of {number1} and {number2} is {ToMultiply()} ");
            Console.WriteLine($"Difference of {number1} and {number2} is {ToSubtract()} ");
            Console.WriteLine($"Remainder of {number1} and {number2} is {ToDivide()} ");
            Console.WriteLine($"Modulo Remainder of {number1} and {number2} is {ToModulo()} ");
        }
    }
}
