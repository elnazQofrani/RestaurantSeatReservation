namespace BookTableReservation.Services
{
    public interface ISeatService
    {
        Task<bool> IsSeatsAvailable(int id, DateTime desiredDateTime, TimeSpan desireStartTime);
    }
}
