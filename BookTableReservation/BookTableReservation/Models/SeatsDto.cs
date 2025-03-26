using BookTableReservation.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookTableReservation.Models
{
    public class SeatsDto
    {
        public int Id { get; set; }

        public int SeatNumber { get; set; }

    }
}
