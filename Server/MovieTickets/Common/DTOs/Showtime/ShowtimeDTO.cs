using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Showtime
{
    public class ShowtimeDTO
    {
        public Guid ShowtimeId { get; set; }
        public Guid MovieId { get; set; }
        public string MovieName { get; set; }
        public Guid RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string TheaterName { get; set; }
        public string CityName { get; set; }
        public DateTime ShowtimeDate { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
