using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Common.DTOs.Actor
{
    public class ActorRoleDTO
    {
        public string ActorName { get; set; } = string.Empty;
        public string? ActorDescription { get; set; }
        public string? Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public IFormFile? ActorImageFile { get; set; }
        public string CharacterName { get; set; } = string.Empty;
    }

}
