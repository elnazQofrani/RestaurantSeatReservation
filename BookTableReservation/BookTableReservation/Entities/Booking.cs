using BookTableReservation.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTableReservation.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int SeatId { get; set; }

        [Required]
        public DateTime BookingDateTime { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public BookingStatus Status { get; set; }

        public Customer Customer { get; set; }

        public Seat Seat { get; set; }

    }


}

