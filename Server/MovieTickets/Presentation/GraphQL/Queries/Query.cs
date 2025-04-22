using Application.Queries.City;
using Application.Usecases.Cities;
using Application.Usecases.Movies;
using Application.Usecases.Users;
using Common.DTOs.City;
using Common.DTOs.Movie;
using Common.DTOs.User;
using Common.Models;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Data;
using MediatR;
using System.Threading.Tasks;

namespace MovieTickets.Presentation.GraphQL.Queries
{
    public class Query
    {
 
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public async Task<ResponseModel<IQueryable<CityDTO>>> GetCities([Service] IMediator mediator)
        {
            var cities = await mediator.Send(new GetAllCitiesQuery());
            return new ResponseModel<IQueryable<CityDTO>>
            {
                Success = true,
                Message = "Cities retrieved successfully",
                Data = cities.Data.AsQueryable()
            };
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