using System.ComponentModel.DataAnnotations;

namespace ExerciseApp1
{
    internal class Program
    {
        string word;
        string ShortestString = "";
        string LongestString = "";
        public void GetString()
        {
            Console.Write("Enter The Word : ");
            word = Console.ReadLine();
        }
        public string FuncLongestString() 
        {
            int MaxLength = 0;
            //string[] words = word.Split(',');
            foreach (string s in word.Split(',')) 
            {
                if (s.Length > MaxLength)
                {
                    MaxLength = s.Length;
                    LongestString = s;
                }
                else if (s.Length == MaxLength) 
                {
                    LongestString = LongestString + " " + s;
                }
            }
            return LongestString;

        }
        public string FuncShortestString()
        {
            int MinLength = word.Length;
            string[] words = word.Split(',');
            foreach (string s in words)
            {
                if (s.Length < MinLength)
                {
                    MinLength = s.Length;
                    ShortestString = s;
                }
                else if(s.Length == MinLength)
                {
                    ShortestString = ShortestString + " " + s;
                }
            }

            return ShortestString;
        }

        public void PrintOutput()
        {
            Console.Write("The Longest String is/are : ");
            for(int i=0; i<LongestString.Length; i++)
            {
                Console.Write(LongestString[i]);
            }

            Console.Write("\nThe Shortest String is/are : ");
            for (int i = 0; i < ShortestString.Length; i++)
            {
                Console.Write(ShortestString[i]);
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.GetString();
            program.FuncLongestString();
            program.FuncShortestString();
            program.PrintOutput();
            Console.ReadKey();
        }
    }
}