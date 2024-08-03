using OnlineHotel.DAL.Entity;
using System.ComponentModel.DataAnnotations;

namespace OnlineHotelReservation.ViewModels
{
    public class RoomTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
