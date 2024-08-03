using Microsoft.Extensions.Logging;
using OnlineHotel.BLL.Interfaces;
using OnlineHotel.DAL.Data;
using OnlineHotel.DAL.Entity;
using OnlineHotel.Utility;

namespace OnlineHotel.BLL.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;
        ILogger<RoomRepository> _iLogger;

        public RoomRepository(ILogger<RoomRepository> iLogger, ApplicationDbContext context)
        {
            _iLogger = iLogger;
            _context = context;
        }

        public async Task<Room> AddRoom(Room room)
        {
            var result = await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public Task DeleteRoom(int id)
        {
            var room = _context.Rooms.Find(id);
            _context.Rooms.Remove(room);
            return _context.SaveChangesAsync();
        }

        public PageResult<Room> GetAll(int pageNumber, int pageSize)
        {
            var totalItems = _context.Rooms.Count();
            var rooms = _context.Rooms
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToList();

            return new PageResult<Room>
            {
                Data = rooms,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };


        }

        public Room GetRoomById(int id)
        {
            var room = _context.Rooms.Find(id);
            return room;
        }

        public Task UpdateRoom(Room room)
        {
            var result = _context.Rooms.Update(room);
            return _context.SaveChangesAsync();
        }
    }
}
