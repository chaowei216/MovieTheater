using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Showtime
    {
        public Guid ShowtimeId { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime ShowtimeDate { get; set; }
        public int AvailableSeat { get; set; }
        public DateTime CreateAt { get; set; }

        // Mối quan hệ 1-n: Một Showtime có nhiều Tickets
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
