using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using ADOExerciseApp;

namespace AdoDisConApp
{
    internal class Program
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
            objChild.FetchProfiles();

            Console.WriteLine("Hello, World!");
        }
    }
}