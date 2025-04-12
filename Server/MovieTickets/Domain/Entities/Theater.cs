using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Theater
    {
        public Guid TheaterId { get; set; }
        public string TheaterName { get; set; }
        public string Location { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public DateTime CreateAt { get; set; }

        // Mối quan hệ 1-n: Một Theater có nhiều Rooms
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
