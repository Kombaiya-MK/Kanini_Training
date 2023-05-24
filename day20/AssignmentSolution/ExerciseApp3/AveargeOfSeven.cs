using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp3
{
    internal class AveargeOfSeven
    {
        public int number { get; set; }
        public int count = 0;
        public double GetInput() 
        {
            double Sum = 0;
            Console.Write("Enter Number : ");
            number = Convert.ToInt32(Console.ReadLine());
            while (number >= 0)
            {
                Sum += check7Multiple(number);
                Console.Write("Enter Number : ");
                number = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine($"Sum : {Sum}    Count : {count}");
            return Sum / count;   
        }
        public int check7Multiple(int number) 
        {
            if (number % 7 == 0)
            {
                count++;
                return number;
            }
            else {
                return 0;
            }
        }

        public void ShowOutput() 
        {
            Console.WriteLine($"The average of 7 Multiples is {GetInput()}");
        }
    }
}
