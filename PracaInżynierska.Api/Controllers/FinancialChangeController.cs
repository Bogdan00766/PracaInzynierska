using Microsoft.AspNetCore.Mvc;
using PracaInżynierska.Application.Dto;
using PracaInżynierska.Application.Interfaces;

namespace PracaInżynierska.Api.Controllers
{
    [ApiController]
    [Route("api/financialchanges")]
    public class FinancialChangeController : Controller
    {
        private readonly ILogger<FinancialChangeController> _logger;
        private readonly IFinancialChangeService _fcService;

        public FinancialChangeController(ILogger<FinancialChangeController> logger, IFinancialChangeService fcService)
        {
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
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
