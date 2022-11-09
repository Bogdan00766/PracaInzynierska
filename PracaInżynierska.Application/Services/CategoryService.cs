using AutoMapper;
using PracaInżynierska.Application.Dto;
using PracaInżynierska.Application.Interfaces;
using PracaInżynierska.Domain.IRepositories;
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

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            return _mapper.Map<List<CategoryDto>>(await _categoryRepository.FindAllAsync());
        }
    }
}
