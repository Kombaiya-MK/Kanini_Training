using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp2
{
    internal class GreatestNumber
    { 
        public int Max { get; set; }
        public int Number { get; set; }    

        public int GetInput()
        {
            while (Number >= 0)
            {
                Console.Write("Enter Number : ");
                Number = Convert.ToInt32(Console.ReadLine());
                CheckMax();                
            }
            return Max;
            
        }
        public int CheckMax()
        {
            Max = Math.Max(Max, Number);
            return Max;
        }
        public void PrintMax() 
        {
            Console.WriteLine($"The greatest number is {Max}");
        }
    }
}
