using PracaInzynierska.Domain.Models;

namespace PracaInzynierska.Domain.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category? FindByName(string categoryName);
    }
}
