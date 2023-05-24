using JWTAuthenticationApp.Interfaces;
using JWTAuthenticationApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace JWTAuthenticationApp.Services
{
    public class ProductRepo : IRepo<int, Product>
    {
        private JWTContext _context;

        public ProductRepo(JWTContext context) 
        {
            _context = context;
        }

        public Product Add(Product item)
        {
            try
            {
                _context.Products.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(item);
            }
            return null;
        }

        public Product Delete(int key)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == key);
                _context.Products.Remove(product);
                _context.SaveChanges();
                return product;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;

        }

        public Product Get(int key)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == key);
            return product;
        }

        public ICollection<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product Update(Product item)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == item.Id);
                product.Name = item.Name;
                product.Price = item.Price;
                product.Quantity = item.Quantity;
                _context.SaveChanges();
                return product;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }
    }
}
