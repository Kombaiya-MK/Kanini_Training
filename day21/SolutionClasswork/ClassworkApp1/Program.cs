namespace ClassworkApp1
{
    internal class Program
    {
        public void BasicArray()
        {
            int[] numbers = { 1, 2, 3, 4, 5, };
            int[] numbers1 = new int[] { 1, 2, 3, 4, 5 };
            int[] numbers2 = new int[5];

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Enter Number {i+1} : ");
                numbers2[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i] +  "   " + numbers1[i] +"   " + numbers2[i] );
            }
            Console.WriteLine("After Sort : ");
            Array.Sort(numbers2);
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i] + "   " + numbers1[i] + "   " + numbers2[i]);
            }
        }

        void StringArray()
        {
            String name = "Eren Yeager ";
            char[] char_name  = name.ToCharArray();
            char_name[5] = 'J';
            name = new string(char_name);
            // Console.WriteLine(name);
            string[] words = name.Split(' ');
            foreach(string s in words) 
            {
                Console.WriteLine(s);
            }


        }

        void TwoDimensionalArray()
        {
            double[,] tdarray = new double[2,2];
            for(int i = 0; i < tdarray.GetLength(0);i++) //Size of first dimension
            {
                Console.WriteLine($"Scores from class {i+1}");
                for (int j = 0; j < tdarray.GetLength(1); j++)//Size of Second dimension
                {
                    Console.WriteLine($"Enter student {j+1} mark from class {i+1}");
                    tdarray[i,j] = Convert.ToDouble(Console.ReadLine());

                }
            }

            for (int i = 0; i < tdarray.GetLength(0); i++) //Size of first dimension
            {
               // Console.WriteLine($"Scores from class {i + 1}");
                for (int j = 0; j < tdarray.GetLength(1); j++)//Size of Second dimension
                {
                    Console.WriteLine($"Mark of  student {j + 1} mark from class {i + 1} : {tdarray[i,j]}");

                }
            }


        }

        void JaggedArray()
        {
            string[][] skills = new string[2][];
            for(int i = 0;i< skills.Length;i++)
            {
                Console.Write("Enter Number of Skills : ");
                int count = Convert.ToInt32(Console.ReadLine());
                skills[i] = new string[count];
                for (int j = 0; j< skills[i].Length;j++)
                {
                    Console.WriteLine($"Enter Skill {j+1}");
                    skills[i][j] = Console.ReadLine();
                }

            }

            for (int i = 0; i < skills.Length; i++)
            {
                Console.Write($"Skills of Person {i+1} are : ");
                for (int j = 0; j < skills[i].Length; j++)
                {
                    Console.WriteLine($" Skill {j+1} : {skills[i][j]} " ); 
                }

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //new Program().BasicArray();
            //new Program().StringArray();
            //new Program().TwoDimensionalArray();
            new Program().JaggedArray();
        }
    }
}