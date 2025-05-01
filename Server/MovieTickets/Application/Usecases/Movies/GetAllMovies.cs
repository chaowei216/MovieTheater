
using Application.Interfaces.IRepositories;
using Application.Queries.Movies;
using AutoMapper;

using Common.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Usecases.Movies
{
    public class GetAllMovies
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetAllMovies(IMovieRepository  movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(_movieRepository));
            _mapper = mapper;
        }

        public async Task<ResponseModel<IEnumerable<Movie>>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetAllMovie();
            return new ResponseModel<IEnumerable<Movie>>
            {
                Success = true,
                Message = "Movies retrieved successfully",
                Data = _mapper.Map<IEnumerable<Movie>>(movies)
            };
        }
    }
}
