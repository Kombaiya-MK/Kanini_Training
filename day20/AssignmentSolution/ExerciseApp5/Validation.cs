using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp5
{
    internal class Validation
    {
        public string username { get; set; }
        public string password { get; set; }

        public int chances = 3;
        
        public void GetLoginInfo()
        {
            Console.Write("Enter username : ");
            username = Console.ReadLine();
            Console.Write("Enter password : ");
            password = Console.ReadLine();
            validateInfo();

        }
        public void validateInfo()
        {
            if (username == "ABC" && password == "123") 
            {
                Console.WriteLine($"Welcome back! {username}.....");
                chances = 3;
            }
            else
            {
                decreaseChances();
            }
        }

        public void decreaseChances()
        {
            chances--;
            if (chances <= 0)
            {
                Console.WriteLine("Limit reached! try again later...");
                return;
            }
                
            else
            {

                
                while (chances > 0)
                {
                    Console.WriteLine("You've entered wrong credentials! Try again");
                    Console.WriteLine($"Remaining chances {chances}");
                    GetLoginInfo();
                }
            }
            
            
        }

    }
}
