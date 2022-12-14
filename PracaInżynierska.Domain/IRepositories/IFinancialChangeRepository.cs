using PracaInzynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Domain.IRepositories
{
    public interface IFinancialChangeRepository : IRepository<FinancialChange>
    {
        Task<List<FinancialChange>> FindForGuid(Guid guid, DateTime startDate, DateTime endDate);
    }
}
