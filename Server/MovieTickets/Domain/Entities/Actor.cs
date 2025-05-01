using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Actor : BaseEntity
    {
        public string ActorName { get; set; } = string.Empty;
        
        public string? ActorImage { get; set; }
        public string? ActorDescription { get; set; }
        public string? Sex { get; set; } 
        public DateTime? DateOfBirth { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}
