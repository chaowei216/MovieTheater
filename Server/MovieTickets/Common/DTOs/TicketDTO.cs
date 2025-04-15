using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class TicketDTO
    {
        public Guid TicketId { get; set; }
        public Guid ShowtimeId { get; set; }
        public DateTime ShowtimeDate { get; set; } 
        public string MovieName { get; set; } 
        public Guid UserId { get; set; }
        public string UserName { get; set; } 
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
