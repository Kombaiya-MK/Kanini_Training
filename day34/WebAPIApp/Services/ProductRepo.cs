using Microsoft.AspNetCore.DataProtection.KeyManagement;
using WebAPIApp.Interfaces;
using WebAPIApp.Models;

namespace WebAPIApp.Services
{
    public class ProductRepo : IRepo<Product, int>
    {
        static List<Product> products = new List<Product>()
        {
            new Product { Id = 101,Name="Pencil",Price=12.5f,Quantity=2},
            new Product { Id = 102,Name="Eraser",Price=5.0f,Quantity=3}
        };
        public bool Add(Product item)
        {
            if (products.Contains(item))
                return false;
            products.Add(item);
            return true;
        }

        public Product Get(int key)
        {
            Product product = products.SingleOrDefault(x=> x.Id == key);
            return product;
        }

        public ICollection<Product> GetAll()
        {
           if(products.Count > 0)
                return products;
            return null;
        }

        public bool Remove(int Key)
        {
            Product product = Get(Key);
            if(product != null)
            {
                products.Remove(product);
                return true;
            }
            return false; 
        }

        public bool Update(Product item)
        {
            Product product = Get(item.Id);
            if( product != null )
            {
                product.Price = item.Price;
                product.Name = item.Name;
                product.Quantity = item.Quantity;
                return true;
            }
            return false;
        }
    }
}
