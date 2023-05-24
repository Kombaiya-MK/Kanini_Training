using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using ADOExerciseApp;

namespace AdoDisConApp
{
    public class Program
    {

        static void Main(string[] args)
        {
            UserProfile obj = new UserProfile();
            //obj.AddUsingSP();
            //obj.FetchAndDisplayDataUsingSP();

            //obj.UpdateDataUsingSP();
            //obj.DeleteDataUsingSP();
            //obj.FetchProfiles();
            //obj.UpdatePasswordUsingSP();
            UserProfileChild objChild = new UserProfileChild();
            //objChild.FetchProfiles();

            int choice = 1;
            
            while (choice != 0) {
                Console.WriteLine("1.Add Employee info \n2.Show Employee Info \n3.Update Employee Role \n4.Update Employee Password \n5.Delete Employee Info \n6.Show Profiles \n7.Show Profiles(using stored procedures");
                Console.WriteLine("Enter Choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0: Console.WriteLine("Thank you!! Visit again!!!"); break;
                    case 1: obj.AddUsingSP(); break;
                    case 2: obj.FetchAndDisplayDataUsingSP(); break;
                    case 3: obj.UpdateDataUsingSP(); break;
                    case 4: obj.UpdatePasswordUsingSP(); break;
                    case 5: obj.DeleteDataUsingSP(); break;
                    case 6: objChild.FetchProfiles(); break;
                    case 7: obj.FetchProfiles(); break;
                }
            }
            
            //Console.WriteLine("Hello, World!");
        }
    }
}