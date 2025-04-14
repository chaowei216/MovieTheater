using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number.")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Password hash is required.")]
        [StringLength(255, ErrorMessage = "Password hash cannot exceed 255 characters.")]
        public string PasswordHash { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password salt is required.")]
        [StringLength(255, ErrorMessage = "Password salt cannot exceed 255 characters.")]
        public string PasswordSalt { get; set; } = string.Empty;

        [Required(ErrorMessage = "RoleId is required.")]
        public Guid RoleId { get; set; }

        public Role? Role { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();


        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
