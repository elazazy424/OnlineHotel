using Azure;
using OnlineHotel.DAL.Entity;
using OnlineHotel.Utility;

namespace OnlineHotel.BLL.Interfaces
{
    public interface IRoomTypeRepository
    {
        PageResult<RoomType> GetAllRoomTypes(int pageIndex, int pageSize);
        RoomType GetRoomTypeById(int id);
        Task AddRoomType(RoomType roomType);
        Task UpdateRoomType(RoomType roomType);
        Task DeleteRoomType(int id);
        //PageResult<RoomType> GetRoomTypes(int pageIndex, int pageSize);
    }
}
