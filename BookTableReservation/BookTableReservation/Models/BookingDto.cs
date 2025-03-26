using BookTableReservation.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookTableReservation.Models
{
    public class BookingDto
    {
        [Required]

        public int CustomerId { get; set; }

        [Required]
        public int SeatId { get; set; }

        [Required]
        public DateTime BookingDateTime { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

    }
}
