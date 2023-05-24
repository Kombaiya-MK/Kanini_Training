using CalculatorWebAPP.Interfaces;

namespace CalculatorWebAPP.Services
{
    public class CalculatorOperations : IRepo<int>
    {
        public int Addition(int key1, int key2)
        {
            return key1 + key2;
        }

        public int Division(int key1, int key2)
        {
            int res = 0;
            try
            {
                res = key1 / key2;
            }
            catch (DivideByZeroException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return res;
            
        }

        public int Multiplication(int key1, int key2)
        {
            return (key1 * key2);
        }

        public int Subtraction(int key1, int key2)
        {
            return key1 - key2;
        }
    }
}
