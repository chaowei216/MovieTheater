
using AutoMapper;
using Common.DTOs;
using Domain.Entities;
using Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usecases.Movies
{
    public class GetMoviesByTitle
    {
        private readonly IGenericRepository<Movie> _movieRepository;
        private readonly IMapper _mapper;

        public GetMoviesByTitle(IGenericRepository<Movie> movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDTO>> ExecuteAsync(string title)
        {
            var movies = await _movieRepository.FindAsync(m => m.MovieName.ToLower().Contains(title.ToLower()));
            return _mapper.Map<IEnumerable<MovieDTO>>(movies);
        }
    }
}
