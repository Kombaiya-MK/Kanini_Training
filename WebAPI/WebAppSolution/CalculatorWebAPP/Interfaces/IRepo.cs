namespace CalculatorWebAPP.Interfaces
{
    public interface IRepo<T>
    {
        T Addition(T key1, T key2);
        T Subtraction(T key1, T key2);
        T Multiplication(T key1, T key2);
        T Division(T key1, T key2);
    }
}
