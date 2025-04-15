using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket : BaseEntity
    {
        [Required(ErrorMessage = "ShowtimeId is required.")]
        public Guid ShowtimeId { get; set; }

        public Showtime? Showtime { get; set; }

        [Required(ErrorMessage = "UserId is required.")]
        public Guid UserId { get; set; }

        public User? User { get; set; }

        [Required(ErrorMessage = "Seat number is required.")]
        [StringLength(10, ErrorMessage = "Seat number cannot exceed 10 characters.")]
        public string SeatNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than or equal to 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Purchase date is required.")]
        public DateTime PurchaseDate { get; set; }

     
        public Transaction? Transaction { get; set; }
    }
}
