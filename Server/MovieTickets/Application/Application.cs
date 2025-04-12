using Application.Interfaces;

using Application.Usecases;

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
          
            services.AddScoped<GetAllCitiesUseCase>();
            services.AddScoped<GetMoviesByTitleUseCase>();
            services.AddScoped<GetAllUsersUseCase>();
            return services;
        }
    }
}
