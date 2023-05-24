using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WebAppPubs.Interfaces;
using WebAppPubs.Models;
using WebAppPubs.Models.AuthorDTO;

namespace WebAppPubs.Services
{
    public class AuthorService
    {
        private readonly IAuthor<Author> _author;
        private readonly ITitles<Title , string> _title;
        private readonly ITokenGenerate _tokenService;

        public AuthorService() { }
        public AuthorService(IAuthor<Author> author , ITitles<Title , string> title , ITokenGenerate tokenGenerate)
        {
            _author = author;
            _title = title;
            _tokenService = tokenGenerate;
        }
        public ICollection<Title> GetTitles(string authorName)
        {
            return _title.GetTitles(authorName);
        }
        public ICollection<Author> GetAuthor()
        {
            return _author.GetAll();
        }

        public AuthorDTO Login([FromBody] AuthorDTO userDTO)
        {
            AuthorDTO user = new AuthorDTO();
            var userData = _author.Get(userDTO.Username);
            if (userData != null)
            {
                user.Password = userData.AuFname;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }
    }
}


