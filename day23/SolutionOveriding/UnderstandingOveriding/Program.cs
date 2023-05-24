
namespace UnderstandingOveriding
{
    internal class Program
    {
        public void MakeForest(Animal animal)
        {
            animal.eat();
            animal.sleep();
            animal.move();
        }
        static void Main(string[] args)
        {
            Animal monkey = new Monkey();
            Animal Oranguttan = new oranguttan();
            Program program = new Program();
            program.MakeForest(Oranguttan);

        }
    }
}