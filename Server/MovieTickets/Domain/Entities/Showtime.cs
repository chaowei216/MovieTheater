using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Showtime : BaseEntity
    {
        [Required(ErrorMessage = "MovieId is required.")]
        public Guid MovieId { get; set; }

        public Movie? Movie { get; set; }

        [Required(ErrorMessage = "RoomId is required.")]
        public Guid RoomId { get; set; }

        public Room? Room { get; set; }

        [Required(ErrorMessage = "Showtime date is required.")]
        public DateTime ShowtimeDate { get; set; }

        [Required(ErrorMessage = "Available seats is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Available seats must be non-negative.")]
        public int AvailableSeat { get; set; }

  
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
