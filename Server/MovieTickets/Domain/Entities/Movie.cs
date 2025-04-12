using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movie
    {
        public Guid MovieId { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreateAt { get; set; }

   
        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}
