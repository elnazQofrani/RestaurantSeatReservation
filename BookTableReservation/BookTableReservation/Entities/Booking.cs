using BookTableReservation.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTableReservation.Entities
{
    public class Booking
    {
        //With Id
        //Without Id
        // public Booking(int id, int customerId)
        // {
        //     if (id<0)
        //     {
        //         throw new Exception();
        //     }
        //     
        //     CustomerId=customerId;
        // }
        [Key]
        public int Id { get;private set; }


        [Required]
        public int CustomerId { get;private set; }

        [Required]
        public int SeatId { get;private set; }

        [Required]
        public DateTime BookingDateTime { get;private set; }

        [Required]
        public TimeSpan StartTime { get;private set; }

        [Required]
        public BookingStatus Status { get; private set; }

        public Customer Customer { get;private set; }

        public Seat Seat { get;private set; }
        public void SetBookingStatus(BookingStatus Status)
        {
            Status = Status;
        } 
    }
}

