using System.Xml.Linq;

namespace PurchaseXMLApp
{
    internal class Program
    {

        void GetShippingAddress()
        {
            var fileName = "po.xml";
            var dirName = Directory.GetCurrentDirectory();
            var xmlFile = XElement.Load(Path.Combine(dirName, fileName));
            var ShippingAddress = xmlFile.Descendants("PurchaseOrder").Descendants("Address").Where(a => a.Attribute("Type").Value == "Shipping");
            Console.WriteLine("------------------Customer List---------------- ");
            foreach (var item in ShippingAddress)
            {
                Console.WriteLine($"Name : {item.Element("Name").Value}");
            }
        }
        void PriceDetails()
        {
            var fileName = "po.xml";
            var dirName = Directory.GetCurrentDirectory();
            var xmlFile = XElement.Load(Path.Combine(dirName, fileName));
            var priceDetails = xmlFile.Descendants("PurchaseOrder").Descendants("Items").Elements();
            Console.WriteLine("-------------Product Details----------------");
            foreach ( var item in priceDetails)
            {
                Console.WriteLine($"Item Part Number : {item.Attribute("PartNumber").Value}");
                Console.WriteLine($"Product Name : {item.Element("ProductName").Value} ");
                Console.WriteLine($"Product Quantity : {item.Element("Quantity").Value} ");
                Console.WriteLine($"Product Price : {item.Element("USPrice").Value} ");
                Console.WriteLine($"Product Total Price : {Convert.ToDouble(item.Element("USPrice").Value) * Convert.ToDouble(item.Element("Quantity").Value)} ");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");

            }
        }

        void ProductCountsUnderOrders()
        {
            var fileName = "po.xml";
            var dirName = Directory.GetCurrentDirectory();
            var xmlFile = XElement.Load(Path.Combine(dirName, fileName));
            int count = 0;
            var Orders = from p in xmlFile.Descendants("PurchaseOrder")
                         group p.Descendants("Items").Descendants("Item") by p.Attribute("PurchaseOrderNumber").Value;
            Console.WriteLine("-------------------------Purchase Details-----------------");
            foreach( var item in Orders)
            {
                Console.WriteLine("Purchase Id : " + item.Key);
                
                foreach (var item2 in item.ToList())
                {
                    Console.WriteLine("No of products purchased : " + item2.ToList().Count());
                    foreach ( var item3 in item2)
                    {

                        Console.WriteLine("------------------Product Details-----------------");
                        Console.WriteLine($" Product Id : {item3.Attribute("PartNumber").Value}");
                        Console.WriteLine($" Product Name : {item3.Element("ProductName").Value}");
                        Console.WriteLine("**********************************");
                        count++;
                    }
                    
                }

            }
            Console.WriteLine("Total Number of Products : " + count);
        }

        void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("1.Get Shipping Address \n2.Get Price Details \n3.Get Product Count");
                Console.Write("Enter choice : ");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Enter valid Input!!");
                }
                if (choice == 0)
                    break;
                else if (choice == 1)
                    GetShippingAddress();
                else if (choice == 2)
                    PriceDetails();
                else if (choice == 3)
                    ProductCountsUnderOrders();
                else
                    Console.WriteLine("Enter valid choice");


            } while (choice != 0);
        }
        static void Main(string[] args)
        {
            new Program().Menu();
        }
    }
}