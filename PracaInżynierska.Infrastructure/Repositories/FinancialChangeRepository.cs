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
    public class FinancialChangeRepository : Repository<FinancialChange>, IFinancialChangeRepository
    {
        public FinancialChangeRepository(PIDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<FinancialChange>> FindForGuid(Guid guid)
        {
            return await _dbContext.FinancialChange.Where(x => x.Owner.AutoLoginGUID == guid.ToString()).ToListAsync();
        }
    }
}
