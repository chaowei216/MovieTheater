using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreateAt { get; set; }

  
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
