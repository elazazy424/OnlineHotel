using OnlineHotel.DAL.Entity;
using OnlineHotel.Utility;

namespace OnlineHotel.BLL.Interfaces
{
    public interface IRoomRepository
    {
        PageResult<Room> GetAll(int pageNumber, int pageSize);
        Room GetRoomById(int id);
        Task<Room> AddRoom(Room room);
        Task UpdateRoom(Room room);
        Task DeleteRoom(int id);
    }
}
