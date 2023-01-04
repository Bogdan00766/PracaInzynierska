using AutoMapper;
using PracaInzynierska.Application.Dto;
using PracaInzynierska.Application.Interfaces;
using PracaInzynierska.Domain.IRepositories;
using PracaInzynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Category AddCategory(string name)
        {
            Category category = new Category{ Name = name, };
            var cat = _categoryRepository.Create(category);
            if (cat == null) return new Category { Name = "AlreadyExist" };
            return cat;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            return _mapper.Map<List<CategoryDto>>(await _categoryRepository.FindAllAsync());
        }

        public async Task<string> GetCategoryNameByIdAsync(int id)
        {
            var cat = await _categoryRepository.FindByIdAsync(id);
            return cat.Name;
        }
    }
}
