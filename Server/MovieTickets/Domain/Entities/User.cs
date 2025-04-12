using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime CreateAt { get; set; }

 
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

      
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
