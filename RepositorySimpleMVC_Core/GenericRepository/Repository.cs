using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositorySimpleMVC_Core.GenericRepository
{
    public class Repository<TDbContext> : IRepository where TDbContext : DbContext
    {
        private TDbContext dbContext;

        public Repository(TDbContext context)
        {
            dbContext = context;
        }
        public async Task CreateAsync<T>(T entity) where T : class
        {
            dbContext.Set<T>().Add(entity);
            _ =await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            dbContext.Set<T>().Remove(entity);
            _ = await dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> SelectAll<T>() where T : class
        {
            return _ = await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> SelectById<T>(int id) where T : class
        {
           return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            dbContext.Set<T>().Update(entity);
            _ = await dbContext.SaveChangesAsync();
        }
    }
}
