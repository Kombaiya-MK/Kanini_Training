namespace ConsoleApp1
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            int[] A = {-10,-20,-30,-40,100 };
            Console.WriteLine("Hello, World!");
            Console.WriteLine(new Program().solution(A));
        }

        private int solution(int[] A)
        {
            // Implement your solution here
            int Sum = 0;
            int Min_difference = int.MaxValue;
            int R_Sum = 0;
            if (A.Length == 2)
                return Math.Abs(A[1] - A[0]);
            foreach (int num in A)
            {
                Sum += num;
            }

            foreach (int num in A)
            {
                R_Sum += num;
                Sum -= num;
                Console.WriteLine(R_Sum+"\t"+Sum +"\t"+Min_difference);
                int local_diff = Math.Abs(R_Sum - Sum);
                if (local_diff < Min_difference)
                {
                    Min_difference = local_diff;
                }
                //Console.WriteLine(Min_difference);

            }

            return Min_difference;

        }
    }
}