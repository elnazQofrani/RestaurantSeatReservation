using BookTableReservation.Entities;

namespace BookTableReservation.Repositories
{
    public interface IBookingRepository
    {
        Task<Booking> CreatAsync(Booking booking);
        Task<Booking?> GetById(int Id);
        Task Update(Booking booking);


    }
}
