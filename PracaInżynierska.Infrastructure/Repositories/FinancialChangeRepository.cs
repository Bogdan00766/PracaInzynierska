using Microsoft.EntityFrameworkCore;
using PracaInzynierska.Domain.IRepositories;
using PracaInzynierska.Domain.Models;

namespace PracaInzynierska.Infrastructure.Repositories
{
    public class FinancialChangeRepository : Repository<FinancialChange>, IFinancialChangeRepository
    {
        public FinancialChangeRepository(PIDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<FinancialChange>> FindForGuid(Guid guid, DateTime startDate, DateTime endDate)
        {
            return await _dbContext.FinancialChange.Where(x => x.Owner.AutoLoginGUID == guid.ToString() && x.CreationDate.Date >= startDate && x.CreationDate.Date <= endDate).Include(fc => fc.Category).Include(fc => fc.AssetType).ToListAsync();
        }
        public async Task<List<FinancialChange>> FindAllAsync()
        {
            return await _dbContext.FinancialChange
                .Include(fc => fc.Category)
                .ToListAsync();
        }
    }
}
