namespace OnlineHotel.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;
        Task SaveChangesAsync();
    }
}
