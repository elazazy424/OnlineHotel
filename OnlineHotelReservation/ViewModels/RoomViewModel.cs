using OnlineHotel.DAL.Entity;

namespace OnlineHotelReservation.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
        public RoomAvail Status { get; set; }
        public IFormFile RoomPictureFile { get; set; }

    }
}
