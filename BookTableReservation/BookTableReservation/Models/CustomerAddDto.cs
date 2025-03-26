using System.ComponentModel.DataAnnotations;

namespace BookTableReservation.Models
{
    public class CustomerAddDto
    {

        [Required]
        [MaxLength(30 , ErrorMessage = "FirstName has to be a maximum of 30 characters")]
        public string FirstName { get; set; }

        [MaxLength(30 , ErrorMessage = "FirstName has to be a maximum of 30 characters")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

    }
}
