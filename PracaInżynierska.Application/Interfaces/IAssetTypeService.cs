using PracaInzynierska.Application.Dto;
using PracaInzynierska.Domain.Models;

namespace PracaInzynierska.Application.Interfaces
{
    public interface IAssetTypeService
    {
        AssetType AddAssetType(string name);
        Task<List<AssetTypeDto>> GetAllAssetTypesAsync();
    }
}
