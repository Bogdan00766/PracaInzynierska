using PracaInżynierska.Application.Dto;
using PracaInżynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInżynierska.Application.Interfaces
{
    public interface IFinancialChangeService
    {
        FinancialChange Add(FinancialChangeDto dto, Guid guid);
        Task<List<FinancialChangeDto>> GetAllAsync(Guid guid);
        Task<bool> DeleteAsync(int id);
    }
}
