using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelService.Data;
using HotelService.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        readonly DatabaseContext context;
        readonly DbSet<T> db;

        public GenericRepository(DatabaseContext context) {
            this.context = context;
            db = context.Set<T>();
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null) {
            IQueryable<T> query = db;
            if (expression != null) {
                query = query.Where(expression);
            }

            if (includes != null) {
                foreach (var include in includes) {
                    query = query.Include(include);
                }
            }

            if (orderBy != null) {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null) {
            IQueryable<T> query = db;
            if (includes != null) {
                foreach (var include in includes) {
                    query = query.Include(include);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task Insert(T entity) {
            await db.AddAsync(entity);
        }

        public void Update(T entity) {
            db.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(int id) {
            var entity = await db.FindAsync(id);
            db.Remove(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities) {
            await db.AddRangeAsync(entities);
        }

        public void DeleteRange(IEnumerable<T> entities) {
            db.RemoveRange(entities);
        }
    }
}