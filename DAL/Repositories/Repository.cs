using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ForumContext _context;
        private DbSet<T> table;

        public Repository(ForumContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public async Task AddAsync(T item)
        {
             table.Add(item);
            await SaveAsync();
        }

        public async Task DeleteAsync(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            table.Remove(item);
            await SaveAsync();
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await table.ToListAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T item = await table.FindAsync(id);
            return item;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            await SaveAsync();
        }
    }
}
