using JWTAuthenticationApp.Interfaces;
using JWTAuthenticationApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace JWTAuthenticationApp.Services
{
    public class ProductService
    {
        private IRepo<int, Product> _repo;

        public ProductService( IRepo<int , Product> repo) 
        { 
            _repo = repo;
        }

        public ICollection<Product> GetProducts()
        {
            return _repo.GetAll().ToList();
        }
        public Product AddProduct(Product product)
        {
            return _repo.Add(product);
        }
        public ICollection<Product> ProductsInRange(int MinRange , int MaxRange) 
        { 
            var products = _repo.GetAll().Where(p => p.Price >= MinRange && p.Price <= MaxRange);
            return products.ToList();
        }

    }
}
