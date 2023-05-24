using System.Reflection;
using doctorModelLibrary;

namespace doctorClinicOverriding
{
    internal class Program
    {
        ClinicDoctor doc = new ClinicDoctor();
        public void ManageInfo()
        {
            doc.AddDoctors();//Function To add doctors..
            doc.PrintDoctors();
            //doc.CompareDoctors();
            // Console.WriteLine(doc[0][0]); 
            //doc.PrintDoctors();
            //Console.Write("Enter doctor's name that have to be removed : ");
            //string name = Console.ReadLine();
            //doctor d1 = doc[name];
            //doc.removeDoctors(d1);//Function to remove doctors..
            //doc.PrintDoctors();
            //Console.WriteLine(doc[0].Doc_name, doc[1].Doc_name);
            //Console.WriteLine("Enter doctor id's to compare ..");
            //int id1 , id2 ;
            //id1 = Convert.ToInt32(Console.ReadLine());
            //id2 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(doc[0].Doc_name , doc[1].Doc_name);
            //if (doc[id1-101] == doc[id2-101])
            //{
            //    Console.WriteLine($"Both Doctors {doc[id1-101].Doc_name} and {doc[id2-101].Doc_name}  have same years of experience in same field.");
            //}
            //else 
            //{
            //    Console.WriteLine($"Both Doctors {doc[id1 - 101].Doc_name} and {doc[id2 - 101].Doc_name}  don't have same years of experience or from same field.");
            //}
        
        }


        public ClinicDoctor GetDoc()
        {
            return doc;
        }

        public void GetDoctorInfo()
        {
            Console.Write("Enter doctor name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Doctor Info");
            doc[name].ShowDoctorDetails(doc[name]);
            Console.Write("Enter Skill : ");
            string skill = Console.ReadLine();
            Console.WriteLine($"Experience in {skill} is {doc[name][skill]}");
        }
        //public void CompareDoctors() 
        //{
        //    doctor doc1 = new doctor();
        //    doctor doc2 = new doctor();
        //    Console.WriteLine("Enter Two doctor info to compare : ");
            
        //    if (doc1 == doc2)
        //    {
        //        Console.WriteLine($"Both Doctors {doc[id1-101].Doc_name} and {doc[id2-101].Doc_name}  have same years of experience in same field.");
        //    }
        //    else 
        //    {
        //        Console.WriteLine($"Both Doctors {doc[id1 - 101].Doc_name} and {doc[id2 - 101].Doc_name}  don't have same years of experience or from same field.");
        //    }
        //}
        static void Main(string[] args)
        {
            Program program = new Program();
            program.ManageInfo();
            program.GetDoctorInfo();
            //program.CompareDoctors();
            //int option;
            //option = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter Zero to Exit...");
            //Console.WriteLine("1.Add Doctors info \n2.Get doctor info by name \n3.Get skill experience with skill \n4.Remove doctor or skill info");
            //while (option >= 0)
            //{
            //    if (option == 1)


                    
            //}
          
        }
    }
}