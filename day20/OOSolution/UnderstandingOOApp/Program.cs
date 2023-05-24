namespace UnderstandingOOApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Phone p1 = new Phone();
            //p1.Colour = "Blue";
            //p1.CallingPhone();
            //Cycle c1 = new Cycle(2,20.87F, "Hero");
            //Cycle c2;
            //c2 = c1;
            //c1.Display();
            //c1.Brake();
            //c1.Horn();
            //c1.Pedal();
            //c1.Display();
            //Console.WriteLine("Object 2 : ");
            //c2.Display();
            MotorCycle hero = new MotorCycle();
            hero.Pedal();
            hero.Make = "Honda";
            hero.NumberOfWheels = 2;
            Console.ReadKey();

        }
    }
}