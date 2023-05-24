namespace WebAppPubs.Interfaces
{
    public interface ITitles<T , K>
    {
        ICollection<T> GetTitles(K key);
    }
}
