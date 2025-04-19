
using Application.Interfaces.IRepositories;
using Application.Queries.City;
using AutoMapper;
using Common.DTOs.City;
using Common.Models;
using Domain.Entities;

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
            _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(_cityRepository));
            _mapper = mapper;
        }

        public async Task<ResponseModel<IEnumerable<CityDTO>>> Handle(GetAllCities request, CancellationToken cancellationToken)
        {
            var cities = await _cityRepository.GetAllAsync();
            return new ResponseModel<IEnumerable<CityDTO>>
            {
                Success = true,
                Message = "Cities retrieved successfully",
                Data = _mapper.Map<IEnumerable<CityDTO>>(cities)
            };
           
        }
    }
}
