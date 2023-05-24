using EFAppDatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace EFAppDatabaseFirst
{
    internal class Program
    {
        pubsContext context = new pubsContext();

        void GetPublishers()
        {
            //var publishers = context.Publishers.Where(p => p.Country == "USA").ToList();
            var publishers = context.Publishers.FirstOrDefault(p => p.Country == "USA");
            Console.WriteLine(publishers.PubName);
            //foreach (var publisher in publishers)
            //{
            //    Console.WriteLine(publisher.PubName);
            //}
        }
        void LINQCount()
        {
            var publisherCount = context.Publishers.Where(p => p.Country == "USA" || p.Country == "France").Count();
            Console.WriteLine("No of publishers : "+ publisherCount);
        }

        void OrderData()
        {
            var publishers = context.Publishers.OrderByDescending(p => (p.Country)).ToList();
            foreach (var publisher in publishers)
            {
                Console.WriteLine(publisher.PubName + " " + publisher.Country);
            }
        }

        void ValidateAuthor()
        {
            Console.WriteLine("Enter Author first name : ");
            var auFname = Console.ReadLine();
            Console.WriteLine("Enter Author last name : ");
            var auLname = Console.ReadLine();
            Author author = context.Authors.SingleOrDefault( a => a.AuFname == auFname && a.AuLname == auLname);
            if (author == null)
                Console.WriteLine("Enter valid credintials");
            else
                Console.WriteLine("Welcome " + auFname + " " + auLname);
        }
        void GroupBy()
        {
            var publishers = context.Publishers.ToList();
            //var groups = from publisher in publishers
            //             group publisher by publisher.Country;
            var groups = publishers.GroupBy(p => p.Country);
            foreach(var group in groups)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine("\t" + item.PubName);

                }
            }         
        }

        //Take the publisher's name and fetch all the titles that are published by them.
        void GetPublisherTitles()
        {
            var publishers = context.Publishers.Include(p => p.Titles);
            var titles = context.Titles.ToList();
            string pubname = "";
            Console.WriteLine("Enter publisher name : ");
            pubname = Console.ReadLine();
            if(pubname == null)
            {
                Console.WriteLine("Enter valid publisher name : ");
                return;
            }
            else if(context.Publishers.Where(p => p.PubName == pubname).Count() == 0)
            {
                Console.WriteLine("Publisher not available");
                return;
            }
            foreach (var publisher in publishers.Where(p => p.PubName == pubname))
            {
                Console.WriteLine("Publisher : " + publisher.PubName);
                //Console.WriteLine("Published Books ");
                foreach (var title in publisher.Titles)
                {
                      Console.WriteLine("\t" + title.Title1);
                }

            }
        }

        //Take an author ID and print all the details about the author

        void GetAuthorInfo()
        {
            Console.WriteLine("Enter Author Id : ");
            string id;
            id = Console.ReadLine();
            var authors = context.Authors.ToList();
            var author = authors.Where(a => a.AuId == id).FirstOrDefault();
            if(author == null)
            {
                Console.WriteLine("Enter valid author id!!!!");
            }
            else
            {
                Console.WriteLine("---------------------Author Details------------------------");
                Console.WriteLine($"Author  Name  : {author.AuFname} {author.AuLname} \nState : {author.State} \nAddress : {author.Address} \nPhone : {author.Phone}");
            }

        }

        //Take a title name and print the sales details. Also print the total sale amount.
        void PrintSales()
        {
            var sales = context.Titles.Include(t => t.Sales).ToList();
            Console.WriteLine("Available Products :");
            //foreach(var item in context.Titles)
            //{
            //    Console.WriteLine(item.Title1);
            //}
            Console.WriteLine("Enter title of the book");
            string title = Console.ReadLine();
            if(title == null)
            {
                Console.WriteLine("Enter valid input");
                return;
            }
            else if(context.Titles.Where(t => t.Title1 == title).Count() == 0) 
            {
                Console.WriteLine("Book is not available !!");
                return;
            }
            Console.WriteLine("----------------Sales Details-----------------------");
            foreach(var item in sales.Where(s => s.Title1.Equals(title)))
            {
                double total_sale_price = 0;
                Console.WriteLine("Book Name : " + item.Title1);
                foreach (var item2 in item.Sales)
                {
                    Console.WriteLine($"Order Number : {item2.OrdNum} \nOrder date : {item2.OrdDate} \nPrice : {item.Price} \nQty : {item2.Qty}");
                    total_sale_price += (double)item.Price * (int)item2.Qty;
                }
                if (total_sale_price == 0)
                {
                    Console.WriteLine("The product has not been sold!!!");
                }
                else
                {
                    Console.WriteLine("Total Sale price : " + total_sale_price);
                }
               
            }
               
        }

        void menu()
        {
            int choice;
            do
            {
                Console.WriteLine("1.Get Published books \n2.Get Author Info \n3.Print Sales Details \n(Enter 0 to exit)");
                Console.Write("Enter Choice : ");
                while(!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Enter valid input");
                }
                if (choice == 0)
                    break;
                else if (choice == 1)
                {
                    GetPublisherTitles();
                }
                else if (choice == 2)
                    GetAuthorInfo();
                else if (choice == 3)
                    PrintSales();
                else
                    Console.WriteLine("Wrong Choice");
            } while (choice != 0);
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            Program program = new Program();
            //program.menu();
            //program.OrderData();
            program.GetPublishers();
        }
    }
}