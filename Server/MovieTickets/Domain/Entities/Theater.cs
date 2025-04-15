using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Theater : BaseEntity
    {
        [Required(ErrorMessage = "Theater name is required.")]
        [StringLength(100, ErrorMessage = "Theater name cannot exceed 100 characters.")]
        public string TheaterName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(255, ErrorMessage = "Location cannot exceed 255 characters.")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "CityId is required.")]
        public Guid CityId { get; set; }

        public City? City { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
