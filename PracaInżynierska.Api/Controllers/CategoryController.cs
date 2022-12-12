using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracaInzynierska.Application.Dto;
using PracaInzynierska.Application.Interfaces;
using PracaInzynierska.Application.Services;
using PracaInzynierska.PropertyManager.Controllers;

namespace PracaInzynierska.Api.Controllers
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
            else if (cat != null) return Ok();
            return BadRequest();
        }
    }
}
