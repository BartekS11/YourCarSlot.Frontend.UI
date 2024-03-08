using AutoMapper;
using YourCarSlot.Frontend.UI.Models;
using YourCarSlot.Frontend.UI.Services.Base;

namespace YourCarSlot.Frontend.UI.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ReservationRequestDto, ReservationRequestVM>().ReverseMap();
            CreateMap<CreateReservationCommand, ReservationRequestVM>().ReverseMap();
            CreateMap<UpdateParkingSlotCommand, ReservationRequestVM>().ReverseMap();
            //CreateMap<EmployeeVM, Employee>().ReverseMap();
        }
    }
}