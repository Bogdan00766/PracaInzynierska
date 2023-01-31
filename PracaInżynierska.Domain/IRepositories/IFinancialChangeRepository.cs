using PracaInzynierska.Domain.Models;

namespace PracaInzynierska.Domain.IRepositories
{
    public interface IFinancialChangeRepository : IRepository<FinancialChange>
    {
        Task<List<FinancialChange>> FindForGuid(Guid guid, DateTime startDate, DateTime endDate);
    }
}
