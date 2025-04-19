using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

using Infrastructure.Data;


using Infrastructure.Repositories;
using Application.Interfaces.IRepositories;
using Application.Commands.Auth;
using Application.Interfaces.AuthService;
using Domain.Interfaces;
using Infrastructure.Services;
using Application.Models;


namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")),
                    mysqlOptions => mysqlOptions.EnableRetryOnFailure())
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors());
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<ILocalizer, Localizer>();
            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
            return services;
        }
    }
}