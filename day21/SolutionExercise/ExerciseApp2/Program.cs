namespace ExerciseApp2
{
    internal class Program
    {
        public string Word;
        
        public void GetString()
        {
            Console.Write("Enter String : ");
            Word = Console.ReadLine();
        }
        public void SplitString()
        {
            int Min_Freq ;
            string result = ""; 
            string[] words = Word.Split(',');
            Min_Freq = FindLeastRepeatingString(words[0]);
            for (int i = 0; i < words.Length; i++) 
            {
                int Val = FindLeastRepeatingString(words[i]);
                if (Val <= Min_Freq)
                {
                    Min_Freq = Val;
                    result = result + "Word : " + words[i] + $" Maximum Vowel Frequency : {Min_Freq} \n";
                }
            }
            //if (Min_Freq == FindLeastRepeatingString(words[0]))
            //{
            //    result = "Word : " + words[0] + $" Maximum Vowel Frequency : {FindLeastRepeatingString(words[0])} \n" + result;
            //}
            Console.WriteLine(result);
        }

        public int FindLeastRepeatingString(string str)
        {
            
            int[] Vowels_Count = new int[5];
            foreach(char chr in str) 
            {
                if (chr == 'a' || chr == 'A')
                { Vowels_Count[0]++; }
                else if (chr == 'e' || chr == 'E')
                { Vowels_Count[1]++; }
                else if (chr == 'i' || chr == 'I')
                { Vowels_Count[2]++; }
                else if (chr == 'O' || chr == 'o')
                { Vowels_Count[3]++; }
                else if (chr == 'u' || chr == 'U')
                { Vowels_Count[4]++; }
            }
            

            return Vowels_Count.Max();
            
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.GetString();
            program.SplitString();
        }
    }
}