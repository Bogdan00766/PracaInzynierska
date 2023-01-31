using PracaInzynierska.Domain.Models;

namespace PracaInzynierska.Domain.IRepositories
{
    public interface IAssetTypeRepository : IRepository<AssetType>
    {
        AssetType FindByName(string assetTypeName);
    }
}
