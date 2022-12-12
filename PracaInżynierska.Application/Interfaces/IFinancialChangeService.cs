using PracaInzynierska.Application.Dto;
using PracaInzynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Interfaces
{
    public interface IFinancialChangeService
    {
        FinancialChange Add(FinancialChangeDto dto, Guid guid);
        Task<List<FinancialChangeDto>> GetAllAsync(Guid guid);
        Task<bool> DeleteAsync(int id);
        Task<bool> SetReduction(int id1, int id2);
        Task<bool> DeleteReduction(int id1, int id2);
    }
}
