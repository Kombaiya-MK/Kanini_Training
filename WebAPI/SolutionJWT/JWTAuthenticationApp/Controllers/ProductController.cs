using JWTAuthenticationApp.Models;
using JWTAuthenticationApp.Models.DTO;
using JWTAuthenticationApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthenticationApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        private readonly UserService _uservice;

        public ProductController(ProductService Service , UserService uservice)
        {
            _service = Service;
            _uservice = uservice;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Product>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Product>> ListAllProducts()
        {
            var products = _service.GetProducts();
            if(products.Count == 0)
            {
                return NotFound("No Products are available");
            }
            return Ok(products);

        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Product>> ListProductsInRange(int MinRange , int MaxRange)
        {
            var products = _service.ProductsInRange(MinRange , MaxRange);
            if (products.Count == 0)
            {
                return NotFound("No Products are available");
            }
            return Ok(products);

        }

        [HttpPost]
        //[Authorize]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<Product> AddProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("No product is given!!!");
            }
            if (_service.AddProduct(product) == null)
                return BadRequest("Process Failed");
            else
                return Ok(product);
        }
    }
}
