using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class City
    {
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public DateTime CreateAt { get; set; }


        public ICollection<Theater> Theaters { get; set; } = new List<Theater>();

        public City(string cityName)
        {
            CityId  = Guid.NewGuid();
            SetCityName (cityName);
            CreateAt = DateTime.Now;
        }
        public void SetCityName(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
                throw new ArgumentNullException("City Name can not be null");
            if (cityName.Length > 100)
                throw new ArgumentException("City Name can not exceed 100 characters");
                    CityName = cityName;
        }  
            
    }
}
