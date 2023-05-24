using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using CowBullBLLibrary;
using CowBullDALLibrary;
using CowBullModelLibrary;

namespace CowBullFEApp
{
    public class Provider
    {
        ManageGame manage;
        IRepo<User, int> _user;
        IRepo<Attempt, int> _attempt;
        public Provider() 
        {
            _user = new UserRepoADO();
            _attempt = new AttemptRepoADO();
            manage = new ManageGame(_user , _attempt); //Dependency Injection
        }


        //Main Menu
        public void menu()
        {
            int choice;
            do
            {
                Console.WriteLine("------------Welcome to the Game--------------");
                Console.WriteLine("1.Login \n2.Register");
                Console.WriteLine("Enter Type of user : ");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Enter Valid Input : ");
                }

                if (choice == 0)
                    break;
                else if (choice == 1)
                    login();
                else if (choice == 2)
                    register();
                else
                    Console.WriteLine("Enter valid type of user!!");

            } while (choice != 0);
        }

        //Login Portal
        private void login()
        {
            int id;
            Console.WriteLine("Enter Id : ");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Enter Integer Number : ");
            }
            User user = new User();
            user = manage.GetUser(id);
            if (user == null)
                Console.WriteLine("Invalid User!!!");
            else
            {
                Console.WriteLine("Enter Password");
                string password = Console.ReadLine();
                if (password.Equals(user.Password))
                {
                    Console.WriteLine($"Welcome! {user.Name}");
                    GameMenu(user.id);
                }
                else
                {
                    Console.WriteLine("Invalid Password!!");
                }
            }
        }

        //New User Registration
        private void register()
        {
            Console.WriteLine("Please Enter Your Details");
            User user = new User();
            user.id = 1;
            Console.WriteLine("Enter Name : ");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter Age : ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Enter Valid input : ");
            }
            user.age = age;
            user.Password = user.Name + user.age.ToString();
            int id = manage.AddUser(user);
            Console.WriteLine($"Your user id is : {id}");
            menu();
        }


        //----------------Game Menu------------------
        private void GameMenu(int id)
        {
            int choice;
            do
            {
                Console.WriteLine("1.Give Word \n2.Guess Word \nTo Exit press 0 ");
                while(!int.TryParse(Console.ReadLine(),out choice))
                {
                    Console.WriteLine("Enter Valid Input : ");
                }
                if (choice == 0)
                {
                    Console.WriteLine("Bye Bye");
                    break;
                }
                else if (choice == 1)
                    GiveWord(id);
                else if (choice == 2)
                    GuessWord(id);
                else
                    Console.WriteLine("Enter Valid Choice");
            } while(choice != 0);
        }

        //Guess Word
        private void GuessWord(int id)
        {
            bool status = false;
            Console.WriteLine("The Word is Ready \n Start Guessing");
            do
            {
                Console.WriteLine("Enter a word");
                string word = Console.ReadLine();
                manage.CreateAttempt(id, word);
                if(manage.GiveWord(word.ToLower()))
                {
                    Console.WriteLine("Congratualations!!! You Found it!!!");
                    status = true;
                    char choice;
                    Console.WriteLine("Do you want to see your attempt details(Y/N)");
                    choice = Convert.ToChar(Console.ReadLine());
                    if (choice == 'N')
                        Console.WriteLine("Thank You!!!! Play Again later!!!");
                    else
                    {
                        Console.WriteLine("--------------------------------------");
                        foreach (var item in manage.GetAttempts(id))
                        {
                            
                            Console.WriteLine(item);
                            Console.WriteLine("--------------------------------------");

                        }
                    }
                }
                else
                    Console.WriteLine("Sorry!!! Try Again!!!");
            } while (status != true);
            
        }

        //Give word as input
        private void GiveWord(int id)
        {
            Console.WriteLine("Please Enter a Word (Length of 4)  : ");
            string word = Console.ReadLine();
            if(manage.GetGuessWord(word))
                Console.WriteLine("Word Added to the queue successfully!!!");
            else
                Console.WriteLine("Enter valid word!!");

        }
    }
}
