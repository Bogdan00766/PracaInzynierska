using Microsoft.AspNetCore.Mvc;
using PracaInzynierska.Application.Dto;
using PracaInzynierska.Application.Interfaces;
using PracaInzynierska.Application.MachineLearning;
using PracaInzynierska.Application.MachineLearning.Models;

namespace PracaInzynierska.Api.Controllers
{
    [ApiController]
    [Route("api/financialchanges")]
    public class FinancialChangeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMachineLearning _machineLearning;
        private readonly ILogger<FinancialChangeController> _logger;
        private readonly IFinancialChangeService _fcService;

        public FinancialChangeController(ILogger<FinancialChangeController> logger, IFinancialChangeService fcService,ICategoryService categoryService ,IMachineLearning ml)
        {
            _categoryService = categoryService;
            _machineLearning = ml;
            _logger = logger;
            _fcService = fcService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllByGuid(string? startDate = "01:01:0001", string? endDate = "01:01:9900")
        {
            var guidString = Request.Cookies["GUID"];
            Guid guid;
            if (Guid.TryParse(guidString, out guid))
                return Ok(await _fcService.GetAllByGuidAsync(guid, startDate, endDate));
            return BadRequest("GUID parse error");
        }

        [HttpPost]
        public IActionResult Add(FinancialChangeDto dto)
        {
            var guidString = Request.Cookies["GUID"];
            Guid guid;
            try
            {
                guid = Guid.Parse(guidString);
                _fcService.Add(dto, guid);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("suggestcategory")]
        public async Task<IActionResult> SuggestCategoryAsync(string name, float value)
        {
            MLFinancialChangeDto dto = new MLFinancialChangeDto() { Name = name, Value = value };
            var guidString = Request.Cookies["GUID"];
            Guid guid;
            try
            {
                //guid = Guid.Parse(guidString);
                var categoryId = await _machineLearning.NaiveBayesPredict(dto);
                var catName = await _categoryService.GetCategoryNameByIdAsync(categoryId);
                CategoryDto cd = new CategoryDto()
                {
                    Name = catName
                };

                return Ok(cd);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _fcService.DeleteAsync(id)) return Ok();
            return BadRequest("Deleting error");
        }
        [HttpPost("reductions")]
        public async Task<IActionResult> SetReduction(SetReduction reductions)
        {
            if (reductions.Id1 == reductions.Id2) return BadRequest("IDs cannot be the same");
            try
            {
                if (await _fcService.SetReduction(reductions.Id1, reductions.Id2)) return Ok();
            }
            catch(ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            return BadRequest("Setting Reduction error");
        }
        [HttpGet("reductions")]
        public async Task<IActionResult> DeleteReduction(int id1, int id2)
        {
            try
            {
                if (await _fcService.DeleteReduction(id1, id2)) return Ok();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            return BadRequest("Setting Reduction error");
        }
    }
    public class SetReduction
    {
        public int Id1 { get; set; }
        public int Id2 { get; set; }
    }
}
