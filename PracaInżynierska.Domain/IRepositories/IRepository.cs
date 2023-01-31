using PracaInzynierska.Domain.Models;

namespace PracaInzynierska.Domain.IRepositories
{
    public interface IRepository<T> where T : Entity
    {
        T Create(T e);
        T Update(T e);
        T Delete(T e);
        Task<T> FindByIdAsync(int id);
        Task<List<T>> FindAllAsync();
        Task SaveAsync();
        Task DisposeAsync();
    }
}
