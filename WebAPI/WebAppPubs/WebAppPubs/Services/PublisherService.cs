using Microsoft.EntityFrameworkCore;
using WebAppPubs.Interfaces;
using WebAppPubs.Models;

namespace WebAppPubs.Services
{
    public class PublisherService
    {
        private readonly IPublishers<Publisher> _pubs;
        private readonly ITitles<Title, string> _title;

        public PublisherService() {
        }
        public PublisherService(IPublishers<Publisher> pubs , ITitles<Title , string> titles)
        {
            _pubs = pubs;
            _title = titles;
            
        }
        public ICollection<Title> GetTitles(string PubName)
        {
            return _title.GetTitles(PubName);
        }
        public ICollection<Publisher> GetPubs()
        {
            return _pubs.GetAll();
        }
    }
}
