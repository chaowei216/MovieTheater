using Application.Interfaces.IRepositories;
using Application.Queries.Theaters;
using AutoMapper;
using Common.Models;
using Domain.Entities;

namespace Application.Usecases.Theaters
{
    public class GetAllTheaters
    {
        private readonly IGenericRepository<Theater> _theaterRepository;
        private readonly IMapper _mapper;

        public GetAllTheaters(IGenericRepository<Theater> theaterRepository, IMapper mapper)
        {
            _theaterRepository = theaterRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel<IEnumerable<Theater>>> Handle(GetAllTheatersQuery request, CancellationToken cancellationToken)
        {
            var cities = await _theaterRepository.GetAllAsync();
            return new ResponseModel<IEnumerable<Theater>>
            {
                Success = true,
                Message = "Theaters retrieved successfully",
                Data = _mapper.Map<IEnumerable<Theater>>(cities)
            };
        }

    }
}
