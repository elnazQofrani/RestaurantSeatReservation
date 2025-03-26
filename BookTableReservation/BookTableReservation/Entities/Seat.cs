using System.ComponentModel.DataAnnotations;

namespace BookTableReservation.Entities
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SeatNumber { get; set; }
     
        public ICollection<Booking> Bookings { get; set; }

    }
}
