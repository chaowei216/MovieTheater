using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
