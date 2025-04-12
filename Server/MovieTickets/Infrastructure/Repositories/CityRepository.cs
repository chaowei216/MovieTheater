using Application.Interfaces;
using Domain.Entities;
using Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly IGenericRepository<City> _genericRepository;

        public CityRepository(IGenericRepository<City> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await _genericRepository.GetAllAsync();
        }
    }
}
