using System.Threading.Tasks;

namespace Application.Core
{
    public interface IExecuting<T>
    {
        Task<T> ExecuteAsync(T obj);
    }    
}