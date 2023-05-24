using WebAPIApp.Interfaces;
using WebAPIApp.Models;

namespace WebAPIApp.Services
{
    public class ProductRepoEF : IRepo<Product, int>
    {
        private readonly ShopContext _context;

        public ProductRepoEF()
        {
            
        }

        public ProductRepoEF(ShopContext context) 
        { 
            _context = context;
        }

        public bool Add(Product item)
        {
            try
            {
                _context.Products.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public Product Get(int key)
        {
            Product product = _context.Products.SingleOrDefault(x => x.Id == key);
            return product;
        }

        public ICollection<Product> GetAll()
        {
            var products = _context.Products.ToList();
            if(products.Count > 0)
            {
                return products;
            }
            return null;
        }

        public bool Remove(int Key)
        {
            var product = Get(Key);
            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Product item)
        {
            var product = Get(item.Id);
            if(product != null) 
            { 
                product.Name = item.Name;
                product.Price = item.Price;
                product.Quantity = item.Quantity;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
