using Application.Usecases;
using Common.DTOs;
using HotChocolate;
using HotChocolate.Data;

using System.Threading.Tasks;

namespace MovieTickets.Presentation.GraphQL.Queries
{
    public class Query
    {
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<CityDTO>> GetCities([Service] GetAllCitiesUseCase useCase)
        {
            var cities = await useCase.ExecuteAsync();
            return cities.AsQueryable();
        }

        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<MovieDTO>> GetMovies([Service] GetMoviesByTitleUseCase useCase, string? title)
        {
            var movies = await useCase.ExecuteAsync(title ?? "");
            return movies.AsQueryable();
        }

        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<UserDTO>> GetUsers([Service] GetAllUsersUseCase useCase)
        {
            var users = await useCase.ExecuteAsync();
            return users.AsQueryable();
        }
    }
}