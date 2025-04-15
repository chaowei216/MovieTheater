using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class RoomDTO
    {
        public Guid RoomId { get; set; }
        public Guid TheaterId { get; set; }
        public string TheaterName { get; set; } 
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
