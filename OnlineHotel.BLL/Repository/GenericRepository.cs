using Microsoft.EntityFrameworkCore;
using OnlineHotel.BLL.Interfaces;
using OnlineHotel.DAL.Data;
using System.Linq.Expressions;

namespace OnlineHotel.BLL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        #region getAllAsync
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }
        #endregion
        #region Add
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        #endregion
        #region addAsync
        public Task<T> AddAsync(T entity)
        {
            dbSet.Add(entity);
            return Task.FromResult(entity);
        }
        #endregion
        #region delete
        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
        #endregion
        #region deleteAsync
        public async Task<T> DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            return  entity;
        }
        #endregion
        #region Dispose
        private bool disposed = false;
        public  void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool v)
        {
            if (!disposed)
            {
                if (v)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        #endregion
        #region getByIdAsync
        public async Task<T> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }
        #endregion
        #region update
        public void Update(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        #endregion
        #region updateAsync
        public async Task<T> UpdateAsync(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        #endregion
    }
}
