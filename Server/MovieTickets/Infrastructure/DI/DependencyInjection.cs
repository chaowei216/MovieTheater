using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.IRepositories;
using Infrastructure.Mappings;
using Infrastructure.Repositories;


namespace MovieTickets.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
     
            services.AddDbContext<MovieDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 0))));

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}