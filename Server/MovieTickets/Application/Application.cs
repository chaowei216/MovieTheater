
using Application.Mappings;
using Application.Usecases.Cities;
using Application.Usecases.Movies;
using Application.Usecases.Showtimes;
using Application.Usecases.Theaters;
using Application.Usecases.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application
{
    public static class Application
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<GetAllCities>();
            services.AddScoped<GetMoviesByTitle>();
            services.AddScoped<GetAllUsers>();
            services.AddScoped<GetAllTheaters>();
            services.AddScoped<GetAllShowtimes>(); ;
            return services;
        }
    }
}
