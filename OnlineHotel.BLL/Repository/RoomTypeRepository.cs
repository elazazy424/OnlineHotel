using Azure;
using Microsoft.Extensions.Logging;
using OnlineHotel.BLL.Interfaces;
using OnlineHotel.DAL.Data;
using OnlineHotel.DAL.Entity;
using OnlineHotel.Utility;

namespace OnlineHotel.BLL.Repository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly ApplicationDbContext _context;
        ILogger<RoomTypeRepository> _logger;
        public RoomTypeRepository(ApplicationDbContext context, ILogger<RoomTypeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task AddRoomType(RoomType roomType)
        {
            await _context.RoomTypes.AddAsync(roomType);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteRoomType(int id)
        {
            var roomType = await _context.RoomTypes.FindAsync(id);
            _context.RoomTypes.Remove(roomType);
            await _context.SaveChangesAsync();
        }
        public PageResult<RoomType> GetAllRoomTypes(int pageIndex, int pageSize)
        {
            // Use DbSet to get the data
            var query = _context.RoomTypes;

            // Get the total count
            var count = query.Count();

            // Get the data
            var data = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            // Return the data
            return new PageResult<RoomType>
            {
                Data = data,
                TotalItems = count,
                PageNumber = pageIndex,
                PageSize = pageSize
            };
        }
        public RoomType GetRoomTypeById(int id) => _context.RoomTypes.Find(id);
        public async Task UpdateRoomType(RoomType roomType)
        {
            _context.RoomTypes.Update(roomType);
            await _context.SaveChangesAsync();
        }
        //public PageResult<RoomType> GetRoomTypes(int pageIndex, int pageSize)
        //{
          
        //}
    }
}
