using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp4
{
    internal class StringLength
    {
        public string username { get; set; }
        public int length = 0;
        public void GetInput()
        {
            Console.Write("Enter user name : ");
            username = Console.ReadLine();
            FindLength(username);

        }
        public void FindLength(string username)
        {
            for (int i = 0; i < username.Length; i++) 
            {
                if ( (username[i] >= 'a' && username[i] <= 'z') || (username[i] >= 'A' && username[i] <= 'Z') )
                {
                    length++;
                }
            }
        }

        public void printLength()
        {
            Console.WriteLine($"The length of the username : {username} is {length}");
        }
    }
}
