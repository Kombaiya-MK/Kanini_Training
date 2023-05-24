namespace DoctorClinicApp
{
    internal class Program
    {
        IndexerClinicDoctor doc;
        public Program()
        {
            doc = new IndexerClinicDoctor();
        }

        public void ManageDoctorInfo()
        {
            doc.AddDoctors();
            doc.PrintDoctors();
        }

        public void UseIndexer()
        {
            //Doctor ID that
            Console.Write("Enter the doctor ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Doctor {id} details");
            int doctor_idx = id - 101;
            doc[doctor_idx].ShowDoctorDetails(doc[doctor_idx]);
            Console.WriteLine($"Enter number of skill has to be replaced");//Skill ID
            int skill_number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the new skill");
            string name = Console.ReadLine();
            Console.WriteLine($"The skill is changed from {doc[doctor_idx][skill_number]} to {name}");
            doc[doctor_idx][skill_number-1] = name;
            doc[doctor_idx].ShowDoctorDetails(doc[doctor_idx]);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.ManageDoctorInfo();
            program.UseIndexer();

        }
    }
}