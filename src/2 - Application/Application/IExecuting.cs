namespace Application.Core
{
    public interface IExecuting<T>
    {
        T Execute(T obj);
    }
}