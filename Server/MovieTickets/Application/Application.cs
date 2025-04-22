
using Application.Handlers.City;
using Application.Mappings;
using Application.Queries.City;
using Application.Usecases.Cities;
using Application.Usecases.Movies;
using Application.Usecases.Showtimes;
using Application.Usecases.Theaters;
using Application.Usecases.Users;
using FluentValidation;

using Microsoft.Extensions.DependencyInjection;


namespace Application
{
    public static class Application
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<GetAllCities>();
            services.AddScoped<GetMoviesByTitle>();
            services.AddScoped<GetAllUsers>();
            services.AddScoped<GetAllTheaters>();
            services.AddScoped<GetAllShowtimes>();
           
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application).Assembly));
            services.AddValidatorsFromAssembly(typeof(Application).Assembly);
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetAllCitiesQueryHandler).Assembly);
            });
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            return services; 
        }
    }
}
