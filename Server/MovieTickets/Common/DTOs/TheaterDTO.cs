using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class TheaterDTO
    {
        public Guid TheaterId { get; set; }
        public string TheaterName { get; set; }
        public string Location { get; set; }
        public Guid CityId { get; set; }
        public string CityName { get; set; }    
        public DateTime CreateAt { get; set; }
    }
}
