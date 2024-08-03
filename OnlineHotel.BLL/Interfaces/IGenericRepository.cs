using System.Linq.Expressions;

namespace OnlineHotel.BLL.Interfaces
{
    public interface IGenericRepository<T> : IDisposable
    {
        void Add(T entity);
        Task<T> AddAsync(T entity);
        void Delete(T entity);
        Task<T> DeleteAsync(T entity);
        Task<List<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = ""
            );
        Task<T> GetByIdAsync(object id);
        //update
        void Update(T entity);
        Task<T> UpdateAsync(T entity);
      
    }
}
