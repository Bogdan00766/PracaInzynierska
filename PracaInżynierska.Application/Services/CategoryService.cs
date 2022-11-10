using AutoMapper;
using PracaInżynierska.Application.Dto;
using PracaInżynierska.Application.Interfaces;
using PracaInżynierska.Domain.IRepositories;
using PracaInżynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInżynierska.Application.Services
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
    }
}
