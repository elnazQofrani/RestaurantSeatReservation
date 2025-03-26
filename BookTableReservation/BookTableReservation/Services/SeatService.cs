
using BookTableReservation.Repositories;

namespace BookTableReservation.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository seatRepository;
        public SeatService(ISeatRepository seatRepository)
        {
            this.seatRepository = seatRepository;
        }

        public Task<bool> IsSeatsAvailable(int id, DateTime desiredDateTime, TimeSpan desireStartTime)
        {

          return  seatRepository.IsSeatsAvailable(id, desiredDateTime, desireStartTime);
        }


    }
}
