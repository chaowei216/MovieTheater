using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movie : BaseEntity
    {
        [Required(ErrorMessage = "Movie name is required.")]
        [StringLength(255, ErrorMessage = "Movie name cannot exceed 255 characters.")]
        public string MovieName { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required(ErrorMessage = "IsPublic is required.")]
        public bool IsPublic { get; set; } = false;

        [Required(ErrorMessage = "Duration is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than 0.")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Release date is required.")]
        public DateTime ReleaseDate { get; set; }

        
        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}
