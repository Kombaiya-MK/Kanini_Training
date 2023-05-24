using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationSample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello world";
        }

        [HttpGet]
        public string Get(int id)
        {
            return $"Entered Number : {id}";
        }
        

    }
}
