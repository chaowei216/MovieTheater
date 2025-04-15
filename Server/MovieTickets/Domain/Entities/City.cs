using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class City : BaseEntity
    {
        [Required(ErrorMessage = "City name is required.")]
        [StringLength(100, ErrorMessage = "City name cannot exceed 100 characters.")]
        public string CityName { get; set; } = string.Empty;


        public ICollection<Theater> Theaters { get; set; } = new List<Theater>();
    }
}
