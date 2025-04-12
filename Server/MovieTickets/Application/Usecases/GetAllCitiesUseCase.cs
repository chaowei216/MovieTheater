
using Application.Interfaces;
using AutoMapper;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usecases
{
    public class GetAllCitiesUseCase
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetAllCitiesUseCase(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDTO>> ExecuteAsync()
        {
            var cities = await _cityRepository.GetAllCitiesAsync();
            return _mapper.Map<IEnumerable<CityDTO>>(cities);
        }
    }
}
