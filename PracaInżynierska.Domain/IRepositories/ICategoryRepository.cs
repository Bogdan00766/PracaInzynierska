using PracaInzynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Domain.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category? FindByName(string categoryName);
    }
}
