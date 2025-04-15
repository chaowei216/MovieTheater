using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Room : BaseEntity
    {
   

        [Required(ErrorMessage = "TheaterId is required.")]
        public Guid TheaterId { get; set; }

        public Theater? Theater { get; set; }

        [Required(ErrorMessage = "Room number is required.")]
        [StringLength(50, ErrorMessage = "Room number cannot exceed 50 characters.")]
        public string RoomNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Capacity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0.")]
        public int Capacity { get; set; }


        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}
