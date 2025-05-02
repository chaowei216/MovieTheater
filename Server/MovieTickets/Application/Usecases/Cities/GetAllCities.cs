
using Application.Interfaces.IRepositories;
using Application.Queries.Cities;
using AutoMapper;
using Common.Models;
using Domain.Entities;

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

        public async Task<ResponseModel<IEnumerable<City>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            var cities = await _cityRepository.GetAllAsync();
            return new ResponseModel<IEnumerable<City>>
            {
                Success = true,
                Message = "Cities retrieved successfully",
                Data = _mapper.Map<IEnumerable<City>>(cities)
            };
        }
    }
}
