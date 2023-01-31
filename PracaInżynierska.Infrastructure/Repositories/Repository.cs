using Microsoft.EntityFrameworkCore;
using PracaInzynierska.Domain.IRepositories;
using PracaInzynierska.Domain.Models;

namespace PracaInzynierska.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly PIDbContext _dbContext;

        public Repository(PIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T Create(T e)
        {
            _dbContext.Add(e);
            return e;
        }

        public T Delete(T e)
        {
            _dbContext.Remove(e);
            return e;
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public T Update(T e)
        {
            _dbContext.Entry(e).State = EntityState.Modified;
            _dbContext.Update(e);
            return e;
        }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
