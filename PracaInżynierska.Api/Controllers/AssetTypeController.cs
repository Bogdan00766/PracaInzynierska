using Microsoft.AspNetCore.Mvc;
using PracaInżynierska.Application.Dto;
using PracaInżynierska.Application.Interfaces;
using PracaInżynierska.Application.Services;

namespace PracaInżynierska.Api.Controllers
{
    [ApiController]
    [Route("api/assettypes")]
    public class AssetTypeController : Controller
    {
        private readonly ILogger<AssetTypeController> _logger;
        private readonly IAssetTypeService _assetTypeService;

        public AssetTypeController(ILogger<AssetTypeController> logger, IAssetTypeService assetTypeService)
        {
            _logger = logger;
            _assetTypeService = assetTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfAssetTypesAsync()
        {
            var types = await _assetTypeService.GetAllAssetTypesAsync();
            if (types != null)
            {
                return Ok(types);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddAssetType(AssetTypeDto dto)
        {
            var cat = _assetTypeService.AddAssetType(dto.Name);
            if (cat.Name == "AlreadyExist") return Conflict("AssetType already exist");
            else if (cat != null) return Ok();
            return BadRequest();
        }

    }
}
