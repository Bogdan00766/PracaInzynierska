using PracaInzynierska.Domain.IRepositories;
using PracaInzynierska.Domain.Models;

namespace PracaInzynierska.Infrastructure.Repositories
{
    public class AssetTypeRepository : Repository<AssetType>, IAssetTypeRepository
    {
        public AssetTypeRepository(PIDbContext dbContext) : base(dbContext)
        {
        }

        public AssetType? Create(AssetType at)
        {
            var cat = _dbContext.AssetType.Where(x => x.Name == at.Name).FirstOrDefault();
            if (cat != null) return null;
            _dbContext.AssetType.Add(at);
            _dbContext.SaveChanges();
            return at;
        }

        public AssetType FindByName(string assetTypeName)
        {
            return _dbContext.AssetType.Where(x => x.Name == assetTypeName).FirstOrDefault();
        }
    }
}
