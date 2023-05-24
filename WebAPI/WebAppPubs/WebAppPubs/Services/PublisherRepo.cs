using WebAppPubs.Interfaces;
using WebAppPubs.Models;

namespace WebAppPubs.Services
{
    public class PublisherRepo : IPublishers<Publisher> , ITitles<Title , string>
    {
        private readonly pubsContext _context;

        public PublisherRepo(pubsContext context) 
        {
            _context = context;
        }

        public ICollection<Publisher> GetAll()
        {
            return _context.Publishers.ToList();
        }

        public ICollection<Title> GetTitles(string PubName)
        {
            var PublisherTitles = from Publisher in _context.Publishers
                               join Title in _context.Titles on Publisher.PubId equals Title.PubId
                               where Publisher.PubName == PubName
                               select Title;
            return PublisherTitles.ToList();
        }

    }
}
