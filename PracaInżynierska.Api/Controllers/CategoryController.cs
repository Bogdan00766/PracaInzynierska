using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracaInżynierska.Application.Dto;
using PracaInżynierska.Application.Interfaces;
using PracaInżynierska.Application.Services;
using PracaInżynierska.PropertyManager.Controllers;

namespace PracaInżynierska.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> GetListOfCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            if(categories != null)
            {
                return Ok(categories);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryDto dto)
        {
            var cat = _categoryService.AddCategory(dto.Name);
            if (cat.Name == "AlreadyExist") return Conflict("Category already exist");
            else if (cat != null) return Ok(cat.Name);
            return BadRequest();
        }
    }
}
