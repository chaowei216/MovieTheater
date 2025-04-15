using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transaction : BaseEntity
    {
        [Required(ErrorMessage = "UserId is required.")]
        public Guid UserId { get; set; }

        public User? User { get; set; }

        [Required(ErrorMessage = "TicketId is required.")]
        public Guid TicketId { get; set; }

        public Ticket? Ticket { get; set; }

        [Required(ErrorMessage = "Total amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be greater than or equal to 0.")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Transaction date is required.")]
        public DateTime TransactionDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
        public string Status { get; set; } = string.Empty;

        [Required(ErrorMessage = "Payment method is required.")]
        [StringLength(50, ErrorMessage = "Payment method cannot exceed 50 characters.")]
        public string PaymentMethod { get; set; } = string.Empty;
    }
}
