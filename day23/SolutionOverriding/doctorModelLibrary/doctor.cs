namespace doctorModelLibrary
{
    public class doctor
    {
        public int Doc_ID { get; set; }
        public string? Doc_name { get; set; }
        public int Doc_Exp { get; set; }

        public string[,]? speciality;

        public doctor()
        {
            speciality = new string[5, 2];
        }
        public doctor(int S_count)
        {
            speciality = new string[S_count, 2];
        }
        public string this[int index]
        {
            get { return speciality[index,0]; }
            set { speciality[index , 0] = value; }
        }
        public string this[string skill]
        {
            get
            {
                for (int i = 0; i < speciality.Length;i++)
                {
                    if (speciality[i,0] == skill) 
                        return speciality[i,1];
                }
                return "Invalid Skill"; 
            }
        }
        private void GetDetails()
        {
            Console.Write("Enter Doctor Name : ");
            Doc_name = Console.ReadLine();
            Console.Write("Enter Doctor Experience : ");
            Doc_Exp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Enter the Number of Specialities of Doctor {Doc_name}");
            int specility_count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < specility_count; i++)
            {
                Console.Write($"Enter Skill {i + 1} : ");
                speciality[i, 0] = Console.ReadLine();
                Console.Write($"Enter {speciality[i,0]} Experience : ");
                speciality[i, 1] = Console.ReadLine();
            }
        }
        public void GetDoctorDetails()
        {
            Console.Write("Enter Doctor ID : ");
            Doc_ID = Convert.ToInt32(Console.ReadLine());
            GetDetails();

        }
        public void GetDoctorDetails(int ID)
        {
            Doc_ID = ID;
            GetDetails();
        }

        public void ShowDoctorDetails(doctor d3)
        {
            Console.WriteLine("\nDoctor Information");
            Console.WriteLine("***********************************************");
            Console.WriteLine($"Doctor ID : {d3.Doc_ID}");
            Console.WriteLine($"Doctor Name : Dr.{d3.Doc_name}");
            Console.WriteLine($"Doctor Experience : {d3.Doc_Exp} Years");
            Console.WriteLine($"Skills of Doctor {Doc_ID} is : ");
            int count = 0;
            while (speciality[count, 0] != null)
            {
                Console.Write($"Skill {count + 1} . {speciality[count, 0]} \t ");
                Console.Write($"Experience {count + 1} . {speciality[count, 1]} \n");
                count++;
            }
            Console.WriteLine("\n***********************************************");
        }

        public static bool operator == (doctor? left, doctor? right)
        {
            //doctor doc = new doctor();
            bool result = false;
            string skills = "";
           // Console.WriteLine(left.speciality.Length);
            if (left.speciality[0,0] is null || right.speciality[0,0] is null ) {
                
                return result;
             }
            if (left.speciality.Length == 0 || right.speciality.Length == 0)
            {
                return result;
            }
            for (int i = 0; i < left.speciality.Length / 2; i++)
            {
                for (int j = 0; j < right.speciality.Length / 2; j++)
                {
                    if (left.speciality[i, 0] == right.speciality[j, 0] && left.speciality[i, 1] == right.speciality[j, 1])
                        skills += left[i] + " ";
                    //Console.WriteLine($"Both doctors have skill {left[i]} with the experience of {left[left[i]]}");
                    result = true;
                }

            }
            return result;
        }

        public static bool operator != (doctor left, doctor right)
        {
            //doctor doc = new doctor();
            bool result = true;
            for (int i = 0; i < left.speciality.Length / 2; i++)
            {
                for (int j = 0; j < right.speciality.Length / 2; j++)
                {
                    if (left.speciality[i, 0] == right.speciality[j, 0] && left.speciality[i, 1] == right.speciality[j, 1])
                    //Console.WriteLine($"Both doctors have skill {left[i]} with the experience of {left[left[i]]}");
                    result = false;
                }

            }
            return result;
        }

        public void removeSkills(doctor d)
        {
            return;
        }
    }
}