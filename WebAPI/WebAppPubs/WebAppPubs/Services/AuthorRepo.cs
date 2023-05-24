using Microsoft.EntityFrameworkCore;
using WebAppPubs.Interfaces;
using WebAppPubs.Models;

namespace WebAppPubs.Services
{
    public class AuthorRepo : IAuthor<Author> , ITitles<Title,string>
    {
        private readonly pubsContext _context;

        public AuthorRepo()
        {
            
        }
        public AuthorRepo(pubsContext context)
        {
            _context = context;
        }

        public Author Get(string username)
        {
            return _context.Authors.FirstOrDefault(a => a.AuFname == username);    
        }

        public ICollection<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public ICollection<Title> GetTitles(string authorName)
        {
            var AuthorTitles = from tauthor in _context.Titleauthors
                               join author in _context.Authors on tauthor.AuId equals author.AuId
                               join title in _context.Titles on tauthor.TitleId equals title.TitleId
                               where author.AuFname == authorName
                               select title;
            return AuthorTitles.ToList();
        }
    }
}
