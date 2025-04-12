using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Room
    {
        public Guid RoomId { get; set; }
        public Guid TheaterId { get; set; }
        public Theater Theater { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public DateTime CreateAt { get; set; }


        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}
