namespace WebAppPubs.Interfaces
{
    public interface IPublishers<T>
    {
        ICollection<T> GetAll();

    }
}
