using CalculatorWebAPP.Interfaces;
using CalculatorWebAPP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWebAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly IRepo<int> _repo;

        public CalculatorController(IRepo<int> repo)
        {
            _repo = repo;
        }
        [HttpGet("/Add")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Numbers>> GetSum(int num1 , int num2)
        {
            int res = _repo.Addition(num1, num2);
            return Ok(res);
        }

        [HttpGet("/Sub")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Numbers>> GetDiff(int num1, int num2)
        {
            int res = _repo.Subtraction(num1, num2);
            return Ok(res);
        }

        [HttpGet("/Mul")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Numbers>> GetProduct(int num1, int num2)
        {
            int res = _repo.Multiplication(num1, num2);
            return Ok(res);
        }

        [HttpGet("/Div")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ICollection<Numbers>> GetRemainder(int num1, int num2)
        {
            int res = _repo.Division(num1, num2);
            return Ok(res);
        }
    }
}
