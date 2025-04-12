using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public Guid ShowtimeId { get; set; }
        public Showtime Showtime { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string SeatNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime CreateAt { get; set; }

    
        public Transaction Transaction { get; set; }
    }
}
