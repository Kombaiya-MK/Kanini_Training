using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppPubs.Models;
using WebAppPubs.Models.AuthorDTO;
using WebAppPubs.Services;

namespace WebAppPubs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _author;
        private readonly PublisherService _pubs;

        public AuthorController(AuthorService author , PublisherService pubs)
        {
            _author = author;
            _pubs =   pubs;
        }
        [HttpGet]   

        public ActionResult<ICollection<Publisher>> GetAllPublisher()
        {
            var publishers = _pubs.GetPubs().ToList();
            if (publishers.Count > 0)
                return Ok(publishers);
            return NotFound("No publishers are available");
        }

        [HttpGet]
        public ActionResult<ICollection<Title>> GetTitlesByAuthor(string username)
        {
            var titles = _author.GetTitles(username).ToList();
            if(titles.Count > 0)
                return Ok(titles);
            return NotFound($"No books are written by {username}");
        }

        [HttpGet]
        public ActionResult<ICollection<Title>> GetTitlesByPublisher(string pubname)
        {
            var titles = _pubs.GetTitles(pubname).ToList();
            if (titles.Count > 0)
                return Ok(titles);
            return NotFound($"No books are written by {pubname}");
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<AuthorDTO> Login([FromBody] AuthorDTO userDTO)
        {
            var user = _author.Login(userDTO);
            if (user == null)
            {
                return BadRequest("Invalid username or password");
            }
            return Ok(user);
        }
    }
}
