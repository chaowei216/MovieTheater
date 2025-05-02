using Application.Queries.Cities;
using Application.Queries.Movies;
using Application.Queries.Theaters;
using Application.Usecases.Cities;
using Application.Usecases.Movies;
using Application.Usecases.Theaters;
using Common.DTOs.Theater;
using Domain.Entities;

namespace MovieTickets.Presentation.GraphQL.Queries
{
    public class Query
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<City>> GetCities([Service] GetAllCities getAllCitiesUseCase)
        {
            var result = await getAllCitiesUseCase.Handle(new GetAllCitiesQuery(), CancellationToken.None);
            if (!result.Success)
            {
                throw new GraphQLException(result.Message);
            }
            return result.Data;
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Movie>> GetMovies([Service] GetAllMovies useCase)
        {
            var result = await useCase.Handle(new GetAllMoviesQuery(), CancellationToken.None);
            if (!result.Success)
            {
                throw new GraphQLException(result.Message);
            }
            return result.Data.AsQueryable();
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<Theater>> GetTheater([Service] GetAllTheaters getAllTheaters )
        {
            var theaters = await getAllTheaters.Handle(new GetAllTheatersQuery(), CancellationToken.None);
            if (!theaters.Success)
            {
                throw new GraphQLException(theaters.Message);
            }
            return theaters.Data;
        }
    }
}