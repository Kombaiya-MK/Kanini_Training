using System.Threading.Channels;

namespace InBuiltDelegatesApp
{
    public class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public List<int> Scores;
        public override string ToString()
        {
            return First + " " + Last + " " + ID;
        }
    }
    internal class Program
    {
        static List<Student> students = new List<Student>
            {
                new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
                new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
                new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
                new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
                new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
                new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
                new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
                new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
                new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
                new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
                new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
                new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
            };

        static void Main(string[] args)
        {
            //Console.WriteLine("Please enter the name to check");
            //string name = Console.ReadLine();
            ////Predicate<Student> predicate = (s1) =>
            ////{
            ////    if(s1.First==name)
            ////        return true;
            ////    return false;
            ////};
            ////Student student = students.Find(predicate);
            //Student student = students.Find((s1) => s1.First == name);
            //Console.WriteLine(student == null ? "NO such student" : student);

            //int[] scores = {100,76,23,98,89};
            //var PassScores = from score in scores where score > 70 select score;
            //var PassScores = scores.Where(s => s > 70 );
            //foreach ( var score in PassScores )
            //{
            //    Console.WriteLine(score);
            //}
            //var mystudents = from student in students where student.Scores[0] > 80 select student;
            var mystudents = students.Where(s => s.Scores[0] > 80);
            foreach (var student in mystudents)
            {
                Console.WriteLine(student);
            }
        } 
    }
    //internal class Program
    //{
    //    static void CallMethod(Action<int> Myref) 
    //    {
    //        int num = 0;
    //        Console.WriteLine("Enter Number");
    //        num = Convert.ToInt32(Console.ReadLine());
    //        Myref(num);
    //    }

    //    string Square(int num)
    //    {
    //        return $"The square root of {num} is {num * num} ";

    //    }
    //    static bool Check(string pwd)
    //    {
    //        if (pwd.Length > 8)
    //            return true;
    //        return false;
    //    }
    //    static void Main(string[] args)
    //    {
    //        ////Action - Take parameters only. Won't return anything.
    //        //Action<int> del = (num) => Console.WriteLine($"The number {num} after adding one : {++num}");
    //        //CallMethod(del);
    //        //del(10);
    //        ////Func - Take parameters and return values also.
    //        //Func<int, string> sqr = new Program().Square;
    //        //var data = sqr(10);
    //        //Console.WriteLine(data);
    //        Console.WriteLine("Enter Password");
    //        string pwd;
    //        pwd = Console.ReadLine();
    //        Predicate<string> CheckPwd = Check;
    //        Predicate<string> CheckPwd1 = (pwd) => pwd.Length >= 8;
    //        if (CheckPwd1(pwd))
    //            Console.WriteLine("Success");
    //        else
    //            Console.WriteLine("Failed! Password length is suppossed be greater than 8..");

    //        Console.WriteLine("Hello, World!");
    //    }
    //}
}