using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Role
{
    public class RoleDTO
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
