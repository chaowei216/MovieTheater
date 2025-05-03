using Application.Queries.Movies;
using Common.Models;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Movies
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, ResponseModel<Movie>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMovieByIdQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<ResponseModel<Movie>> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.Id);
            if (movie == null)
            {
                return new ResponseModel<Movie> { Success = false, Message = "Movie not found.", Data = null };
            }
            return new ResponseModel<Movie> { Success = true, Message = "Movie retrieved successfully.", Data = movie };
        }
    }
}

