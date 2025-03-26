using System.ComponentModel.DataAnnotations;

namespace BookTableReservation.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string   LastName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]        
        public string Email { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
