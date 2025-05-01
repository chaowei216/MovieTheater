using Application.Interfaces.IRepositories;
using Application.Queries.City;
using Application.Queries.Theaters;
using AutoMapper;
using Common.DTOs.City;
using Common.DTOs.Theater;
using Common.Models;
using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usecases.Theaters
{
    public class GetAllTheaters
    {
        private readonly IMovieRepository<Theater> _theaterRepository;
        private readonly IMapper _mapper;

        public GetAllTheaters(IMovieRepository<Theater> theaterRepository, IMapper mapper)
        {
            _theaterRepository = theaterRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel<IEnumerable<TheaterDTO>>> Handle(GetAllTheatersQuery request, CancellationToken cancellationToken)
        {
            var cities = await _theaterRepository.GetAllAsync();
            return new ResponseModel<IEnumerable<TheaterDTO>>
            {
                Success = true,
                Message = "Theaters retrieved successfully",
                Data = _mapper.Map<IEnumerable<TheaterDTO>>(cities)
            };
        }

    }
}
