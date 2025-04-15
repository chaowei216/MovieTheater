
using AutoMapper;
using Common.DTOs;
using Domain.Entities;
using Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usecases.Cities
{

    public class GetAllCities
    {
        private readonly IGenericRepository<City> _cityRepository;
        private readonly IMapper _mapper;

        public GetAllCities(IGenericRepository<City> cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDTO>> ExecuteAsync()
        {
            var cities = await _cityRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CityDTO>>(cities);
        }
    }
}
