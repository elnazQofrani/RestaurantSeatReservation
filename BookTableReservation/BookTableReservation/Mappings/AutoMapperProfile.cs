using BookTableReservation.Entities;
using BookTableReservation.Models;
using AutoMapper;

namespace BookTableReservation.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {

            CreateMap<Seat, SeatsDto>().ReverseMap();
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Customer, CustomerAddDto>().ReverseMap();

        }
    }
}
