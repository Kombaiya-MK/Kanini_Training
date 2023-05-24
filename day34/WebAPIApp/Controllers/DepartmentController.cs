using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public static List<string> departmentnames = new List<string>();
        [ProducesResponseType(typeof(List<string>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<List<string>>  Get()
        {
            if (departmentnames.Count == 0)
                return NotFound("No dept are available");
            return Ok(departmentnames);
        }

        [ProducesResponseType(typeof(List<string>) , StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("/GetByID")]
        public ActionResult Get(int id)
        {
            if (id < 0 || id >= departmentnames.Count)
                return BadRequest("No data available");
            return Ok(departmentnames[id]);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<string> Post(string name)
        {
            if(!departmentnames.Contains(name))
            {
                departmentnames.Add(name);
                return Created("Departedment Names" , name);
            }
            return BadRequest("No Duplicated Allowed");
            
        }

        [HttpDelete]
        public ActionResult<string>  Delete(string name)
        {
            if(departmentnames.Contains(name))
            {
                departmentnames.Remove(name);
                Ok(name);
            }
            
            return BadRequest("Data is not available to delete");
        }


        [HttpPut]
        public ActionResult<string>  Put(string oldname , string name)
        {
            int id = -1;
            id = departmentnames.IndexOf(oldname);
            if (id != -1)
            {
                departmentnames[id] = name;
                return Ok(name);
            }
            return BadRequest("data not available");
        }
    
    }
}
