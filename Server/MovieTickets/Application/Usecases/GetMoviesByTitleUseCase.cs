
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
    public class GetMoviesByTitleUseCase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetMoviesByTitleUseCase(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDTO>> ExecuteAsync(string title)
        {
            var movies = await _movieRepository.GetMoviesByTitleAsync(title);
            return _mapper.Map<IEnumerable<MovieDTO>>(movies);
        }
    }
}
