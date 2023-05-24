namespace WebAppPubs.Interfaces
{
    public interface IAuthor<T>
    {
        T Get(string id);
        ICollection<T> GetAll();
    }
}
