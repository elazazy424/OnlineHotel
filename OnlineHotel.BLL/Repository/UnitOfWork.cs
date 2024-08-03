using OnlineHotel.BLL.Interfaces;
using OnlineHotel.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineHotel.BLL.Repository
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
           IGenericRepository<T> genericRepository = new GenericRepository<T>(_context);
            return genericRepository;
        }
        #region saveChangesAsync
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        #endregion
        #region Dispose
        private bool disposed = false;
        public void Dispose()
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
    }
}
