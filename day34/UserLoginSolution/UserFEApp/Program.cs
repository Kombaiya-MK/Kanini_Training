using UserModelLibrary;
using UserDALLibrary;
using UserBLLibrary;
namespace UserFEApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            provider provider = new provider();
            provider.menu();
            //provider.GetAll();
        }
    }
}