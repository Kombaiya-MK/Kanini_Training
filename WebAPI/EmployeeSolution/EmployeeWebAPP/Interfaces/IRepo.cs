namespace EmployeeWebAPP.Interfaces
{
    public interface IRepo<T,K>
    {
        bool Add(T item);
        T Get( K  key );
        ICollection<T> GetAll();
        bool Update( T item );
        bool Delete( K key );
    }

}
