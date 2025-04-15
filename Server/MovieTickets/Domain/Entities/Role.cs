﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role : BaseEntity
    {
        [Required(ErrorMessage = "Role name is required.")]
        [StringLength(50, ErrorMessage = "Role name cannot exceed 50 characters.")]
        public string RoleName { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
