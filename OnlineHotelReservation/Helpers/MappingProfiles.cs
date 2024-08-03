using AutoMapper;
using OnlineHotel.DAL.Entity;
using OnlineHotelReservation.ViewModels;

namespace OnlineHotelReservation.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RoomType, RoomTypeViewModel>().ReverseMap();
            CreateMap<Room, RoomViewModel>().ReverseMap();
        }
    }
}
