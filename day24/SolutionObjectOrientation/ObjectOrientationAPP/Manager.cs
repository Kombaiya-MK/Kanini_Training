using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientationAPP
{
    internal abstract class Manager : IBanking
    {
        public void Eat()
        {
            Console.WriteLine("The manager is eating!!!");
        }
        public void ApproveLoan()
        {
            Console.WriteLine("Your loan has been approved !!!");
        }

        public void SolveProblem() 
        {
            Console.WriteLine("Problem Solved!!!");
        }

        public void ConductMeetings()
        {
            Console.WriteLine("Conducts meetings for employees");
        }
        public abstract void AssignWork();


    }
    class BranchManager : Manager
    {
        public override void AssignWork()
        {
            Console.WriteLine("Assigns work for every employee");
        }
    }
}
