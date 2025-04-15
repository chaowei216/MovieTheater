using AutoMapper;
using Common.DTOs;
using Domain.Entities;
using Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<TheaterDTO>> ExecuteAsync()
        {
            var theaters = await _theaterRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TheaterDTO>>(theaters);
        }

    }
}
