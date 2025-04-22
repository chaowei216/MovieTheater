using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Transaction
{
    public class TransactionDTO
    {
        public Guid TransactionId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid TicketId { get; set; }
        public string MovieName { get; set; }
        public DateTime ShowtimeDate { get; set; }
        public string SeatNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
