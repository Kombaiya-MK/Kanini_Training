namespace WebAPIApp.Interfaces
{
    public interface IRepo<T,K>
    {
        T Get(K key);
        ICollection<T> GetAll();
        bool Add(T item);
        bool Remove(K Key);
        bool Update(T item);
    }
}
