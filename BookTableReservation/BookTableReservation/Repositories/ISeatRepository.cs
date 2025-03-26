using BookTableReservation.Entities;

namespace BookTableReservation.Repositories
{
    public interface ISeatRepository
    {
        Task<List<Seat>> GetAvailableSeats(DateTime desiredDateTime, TimeSpan desireStartTime);
        Task<bool> IsSeatsAvailable( int id,  DateTime desiredDateTime, TimeSpan desireStartTime);

    }
}
