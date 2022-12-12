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
        private readonly IMachineLearning _machineLearning;
        private readonly ILogger<FinancialChangeController> _logger;
        private readonly IFinancialChangeService _fcService;

        public FinancialChangeController(ILogger<FinancialChangeController> logger, IFinancialChangeService fcService, IMachineLearning ml)
        {
            _machineLearning = ml;
            _logger = logger;
            _fcService = fcService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var guidString = Request.Cookies["GUID"];
            Guid guid;
            if (Guid.TryParse(guidString, out guid))
                return Ok(await _fcService.GetAllAsync(guid));
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
        public IActionResult SuggestCategory(string name, float value)
        {
            MLFinancialChangeDto dto = new MLFinancialChangeDto() { Name = name, Value = value };
            var guidString = Request.Cookies["GUID"];
            Guid guid;
            try
            {
                guid = Guid.Parse(guidString);
                return Ok(_machineLearning.NaiveBayesPredict(dto));
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
        [HttpDelete("reductions")]
        public async Task<IActionResult> DeleteReduction(SetReduction reductions)
        {
            try
            {
                if (await _fcService.DeleteReduction(reductions.Id1, reductions.Id2)) return Ok();
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
