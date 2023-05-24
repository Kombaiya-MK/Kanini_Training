using System.Xml.Linq;

namespace XMLtoLINQApp
{
    internal class Program
    {
        void XMLLinq()
        {
            var filename = "Books.xml";
            var dirName = Path.GetDirectoryName(filename);
            Console.WriteLine(dirName);
            var XmlFile = XElement.Load(Path.Combine(dirName, filename));
            var book = (from b in XmlFile.Descendants("BOOK")
                       where b.Attribute("ID").Value == "B001"
                       select b.Element("AUTHOR").Value).ToList()[0];
            //var book = XmlFile.Descendants("BOOK").FirstOrDefault(a => a.Attribute("ID").Value == "B001").Element("PRICE").Value;
            Console.WriteLine(book);
            //foreach(var item in book)
            //{
            //    Console.WriteLine(item);
            //}


        }
        static void Main(string[] args)
        {
            new Program().XMLLinq();
            Console.WriteLine("Hello, World!");
        }
    }
}