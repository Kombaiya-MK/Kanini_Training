using System.Data;

namespace ExerciseApp5
{
    internal class Program
    {
        string CC_number;
        public string GetCreditCardNumber() //Function To Get Input String From the user
        {
            Console.WriteLine("Enter Credit Card Number : ");
            CC_number = Console.ReadLine();
            return CC_number;
        }
        public string reverse(string str) //To reverse the given string
        {
            string reverse = "";
            for (int i = str.Length-1; i>=0; i--)
            {
                reverse += str[i];
            }
            return reverse;
        }
        
        public string MultiplyEven(string str) // Multiply the even positioned digits in the credit card
        {
            string return_string = "";
            string[] block = str.Split(' ');
            foreach(string s in block)
            {
                char[] chars = s.ToCharArray();
                for(int i=0; i<chars.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        int value = ((int)(chars[i] - '0') * 2);
                        if (value >= 10)
                        {
                            value = SumOfDigits(value);
                        }
                        return_string += value.ToString();
                    }
                    else
                    {
                        return_string += chars[i];
                    }
                }
                

            }
            
            return return_string;
        }

        public int SumValues(string number) //Sum the modified digits
        {
            int sum = 0;
            foreach(char c in number)
            {
                sum += (int)(c - '0');
            }
            return sum;
        }

        public int Validate(int sum) //Validation 
        {
            if (sum % 10 == 0)
            {
                Console.WriteLine("The Credit card is valid..");
            }
            else
            {
                Console.WriteLine("The Card is not valid..");
            }
            return sum;
        }
        public int SumOfDigits(int n) //To find the sum of the digits
        {
            int temp = n;
            int rem, res = 0;
            while(temp> 0) 
            {
                rem = temp % 10;
                res = res +  rem;
                temp = temp / 10;

            }
            return res;
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            string s = p.GetCreditCardNumber();
            string r = p.reverse(s);
            string num = p.MultiplyEven(r);
            int Sum = p.SumValues(num);

            //Console.WriteLine(r);
            //Console.WriteLine(num);
            //Console.WriteLine(Sum);

            p.Validate(Sum);

        }
    }
}