using PracaInzynierska.Application.Dto;
using PracaInzynierska.Domain.Models;

namespace PracaInzynierska.Application.Interfaces
{
    public interface ICategoryService
    {
        Category AddCategory(string name);
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<string> GetCategoryNameByIdAsync(int id);
    }
}
