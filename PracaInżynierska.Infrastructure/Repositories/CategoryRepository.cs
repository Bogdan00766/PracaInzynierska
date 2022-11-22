using PracaInżynierska.Domain.IRepositories;
using PracaInżynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInżynierska.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(PIDbContext dbContext) : base(dbContext)
        {
        }

        public Category? Create(Category c)
        {
            var cat =_dbContext.Category.Where(x => x.Name == c.Name).FirstOrDefault();
            if (cat != null) return null;
            _dbContext.Category.Add(c);
            _dbContext.SaveChanges();
            return c;
        }

        public Category? FindByName(string categoryName)
        {
            return _dbContext.Category.Where(x => x.Name == categoryName).FirstOrDefault();
        }
    }
}
