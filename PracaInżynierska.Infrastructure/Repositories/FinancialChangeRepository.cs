using Microsoft.EntityFrameworkCore;
using PracaInzynierska.Domain.IRepositories;
using PracaInzynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Infrastructure.Repositories
{
    public class FinancialChangeRepository : Repository<FinancialChange>, IFinancialChangeRepository
    {
        public FinancialChangeRepository(PIDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<FinancialChange>> FindForGuid(Guid guid)
        {
            return await _dbContext.FinancialChange.Where(x => x.Owner.AutoLoginGUID == guid.ToString()).Include(fc => fc.Category).ToListAsync();
        }
        public async Task<List<FinancialChange>> FindAllAsync()
        {
            return await _dbContext.FinancialChange
                .Include(fc => fc.Category)
                .ToListAsync();
        }
    }
}
