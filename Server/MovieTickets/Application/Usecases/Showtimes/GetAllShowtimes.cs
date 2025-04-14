using AutoMapper;
using Common.DTOs;
using Domain.Entities;
using Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usecases.Showtimes
{
    public class GetAllShowtimes
    {
        private readonly IGenericRepository<Showtime> _showtimeRepository;
        private readonly IMapper _mapper;

        public GetAllShowtimes(IGenericRepository<Showtime> showtimeRepository, IMapper mapper)
        {
            _showtimeRepository = showtimeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShowtimeDTO>> ExecuteAsync()
        {
            var showtimes = await _showtimeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ShowtimeDTO>>(showtimes);
        }
    }
}
