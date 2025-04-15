using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class CityDTO
    {
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
