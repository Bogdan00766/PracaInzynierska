using PracaInżynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInżynierska.Domain.IRepositories
{
    public interface IFinancialChangeRepository : IRepository<FinancialChange>
    {
        Task<List<FinancialChange>> FindForGuid(Guid guid);
    }
}
