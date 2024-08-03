namespace OnlineHotel.DAL.Entity
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber{ get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; } = new RoomType();
        public bool IsBooked { get; set; }
        public RoomAvail Status { get; set; }
    }
    public enum RoomAvail
    {
        Booked,Avaliable
    }
}
