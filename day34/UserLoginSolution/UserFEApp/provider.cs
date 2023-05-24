using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModelLibrary;
using UserDALLibrary;
using UserBLLibrary;

namespace UserFEApp
{
    public class provider
    {
        ManageUser manage;
        IRepo<User , int> _user;
        IRepo<User, int> _admin;
        public provider() 
        {
            _user = new UserRepository();
            _admin = new UserRepository();
            manage = new ManageUser(_admin, _user);
        }

        private void GetAll()
        {
            foreach(var item in manage.GetUsers()) 
            {
                Console.WriteLine(item);
            }
        }
        public void menu()
        {
            int choice;
            do
            {
                Console.WriteLine("Type of user ");
                Console.WriteLine("1.Existing User \n2.New User");
                Console.WriteLine("Enter type of user : ");
                while(!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Enter Valid Input!!");
                }

                if (choice == 0)
                    break;
                else if (choice == 1)
                    ShowDetails();
                else if (choice == 2)
                    AddDetails();
                else
                    Console.WriteLine("Enter valid choice");

            } while(choice != 0);
        }

        private void AddDetails()
        {
            User user = new User();
            user.AddDetails();
            if (manage.AddUser(user))
                Console.WriteLine("User info added successfully");
            else
                Console.WriteLine("Add operation failed");
        }

        private void ShowDetails()
        {
            int id;
            Console.WriteLine("Enter Id : ");
            id = Convert.ToInt32(Console.ReadLine());
            string password;
            Console.WriteLine("Enter password : ");
            password = Console.ReadLine();
            if(manage.CheckExistingUser(id, password))
            {
                var user = manage.GetUser(id);
                Console.WriteLine("Welcome back " + user.Name);
                if (user.IsAdmin)
                {
                    Console.WriteLine("Available users in the database");
                    GetAll();
                }
                else
                    Console.WriteLine(user);
            }
        }
    }

    
}
