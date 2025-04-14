using Application.Usecases.Cities;
using Application.Usecases.Movies;
using Application.Usecases.Users;
using Common.DTOs;
using HotChocolate;
using HotChocolate.Data;

using System.Threading.Tasks;

namespace MovieTickets.Presentation.GraphQL.Queries
{
    public class Query
    {
        
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<CityDTO>> GetCities([Service] GetAllCities useCase)
        {
            var cities = await useCase.ExecuteAsync();
            return cities.AsQueryable();
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<MovieDTO>> GetMovies([Service] GetMoviesByTitle useCase, string? title)
        {
            var movies = await useCase.ExecuteAsync(title ?? "");
            return movies.AsQueryable();
        }
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<UserDTO>> GetUsers([Service] GetAllUsers useCase)
        {
            var users = await useCase.ExecuteAsync();
            return users.AsQueryable();
        }
    }
}