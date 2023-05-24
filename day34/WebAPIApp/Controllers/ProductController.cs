using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIApp.Interfaces;
using WebAPIApp.Models;

namespace WebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //public static List<Product> products = new List<Product>();



        //[ProducesResponseType(typeof(List<Product>) , StatusCodes.Status200OK)] // Success Response
        //[ProducesResponseType(StatusCodes.Status404NotFound)] // Failure Response
        //[HttpGet] //Method Invocking Get services
        ////Get Request Function - Read
        //public ActionResult<List<Product>> Get()
        //{
        //    if(products.Count == 0) 
        //        return NotFound("No products available");
        //    return Ok(products);
        //}

        private readonly IRepo<Product,int> _repo;

        public ProductController(IRepo<Product, int> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Product>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Product>> Get()
        {
            IList<Product> products = _repo.GetAll().ToList();
            if (products == null)
                return NotFound("No products availbile at this moment");
            return Ok(products);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(typeof(ICollection<Product>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _repo.Get(id);
            if (product == null)
                return NotFound("No Product with the given ID");
            return Ok(product);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> Add(Product product)
        {
            bool status = _repo.Add(product);
            if (status == false)
                return BadRequest(new Error(1, "Unable to add product"));
            return Created("Product Added", product);
        }
        [HttpPut]
        [ProducesResponseType(typeof(ICollection<Product>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> Edit(int id, Product product)
        {
            Product newProduct = _repo.Get(id);
            if (newProduct == null)
                return NotFound(new Error(2, "No such product is present"));
            bool status = _repo.Update(product);
            if (status == false)
                return BadRequest(new Error(1, "Unable to update product info"));
            return Ok(newProduct);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(ICollection<Product>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> Delete(int id)
        {
            Product newProduct = _repo.Get(id);
            if (newProduct == null)
                return NotFound(new Error(2, "No such product is present"));
            bool status = _repo.Remove(id);
            if (status == false)
                return BadRequest(new Error(1, "Unable to delete product"));
            return Ok(newProduct);
        }
        //[ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)] // Success Response
        //[ProducesResponseType(StatusCodes.Status404NotFound)] // Failure Response
        //[HttpGet("/GetById")]
        ////Get By Id method
        //public ActionResult<Product> Get(int id)
        //{
        //    if (products.Count == 0)
        //        return NotFound("No products available");
        //    foreach (var item in products)
        //    {
        //        if (id == item.Id)
        //        {
        //            return Ok(item);
        //        }
        //    }
        //    return NotFound("Product not available!!");


        //}

        //[ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[HttpPost]
        ////Post Method - Create
        //public ActionResult<string> Post(Product product)
        //{
        //    if(products.Count == 0)
        //        products.Add(product);
        //    foreach(var item in products)
        //    {
        //        if(item.Id == product.Id)
        //        {
        //            return BadRequest("Duplicates not allowed!!!");
        //        }
        //    }
        //    products.Add(product);
        //    return Ok(product.Name);
        //}
        //[ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[HttpDelete] 
        ////Delete Method - Delete
        //public ActionResult<string> Delete(int id)
        //{

        //    if (products.Count == 0)
        //        return BadRequest("No products available");
        //    foreach (var item in products)
        //    {
        //        if(id.Equals(item.Id))
        //        {
        //            products.Remove(item);
        //            return Ok(item.Name);
        //        }
        //    }
        //    return BadRequest("Product not available!!");
        //}

        //[ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[HttpPut]
        ////Put Method - Update
        //public ActionResult<string> Put(Product product) 
        //{
        //    if (products.Count == 0)
        //        return BadRequest("No products available");
        //    foreach (var item in products)
        //    {
        //        if (product.Id == item.Id)
        //        {
        //            item.Name = product.Name;
        //            item.Price = product.Price;
        //            item.Quantity = product.Quantity;
        //            return Ok(item.Name);
        //        }
        //    }
        //    return BadRequest("Product not available!!");
        //}
    }
}
