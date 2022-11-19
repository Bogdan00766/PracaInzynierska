using Microsoft.EntityFrameworkCore;
using PracaInżynierska.Domain.IRepositories;
using PracaInżynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInżynierska.Infrastructure.Repositories
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
    }
}
