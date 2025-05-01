using Application;
using Application.Mappings;
using AutoMapper;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MovieTickets.Presentation.GraphQL.Queries;
using Presentation.GraphQL.Mutations;
using Presentation.Middlewares;
using Serilog;
using System.Reflection;
using System.Text;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Directory.CreateDirectory("logs");

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("Starting application...");

                var builder = WebApplication.CreateBuilder(args);

                builder.Host.UseSerilog();

                Log.Information("Adding Application services...");
                builder.Services.AddApplication();

                Log.Information("Adding Infrastructure services...");
                builder.Services.AddInfrastructure(builder.Configuration);

                builder.Services.AddControllers();
                builder.Services
                    .AddGraphQLServer()
                    .AddQueryType<Query>()
                    .AddMutationType<Mutation>()
                    .AddFiltering()
                    .AddSorting()
                    .AddProjections();

                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("all", policy =>
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod());
                });

                builder.Services.AddHttpContextAccessor();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Movie API",
                        Version = "v1"
                    });
                
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
                    options.IncludeXmlComments(xmlPath);
                });



                builder.Services.Configure<HostOptions>(options =>
                {
                    options.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.Ignore;
                });
              
                var app = builder.Build();

                //if (app.Environment.IsDevelopment())
                //{
                    app.UseSwagger();
                    app.UseSwaggerUI();
                

                app.UseMiddleware<ErrorHandlingMiddleware>();
                app.UseSerilogRequestLogging();
                app.UseHttpsRedirection();
                app.UseCors("all");
                app.UseAuthentication();
                app.UseAuthorization();
                app.MapGraphQL();
                app.MapControllers();
                app.Run(); 
            }
            catch (Exception ex) when (ex is not HostAbortedException && ex.Source != "Microsoft.EntityFrameworkCore.Design")
            {
                Log.Fatal(ex, "Web host terminated unexpectedly");
                Console.WriteLine("ERROR: " + ex.Message);
                Console.WriteLine(ex.ToString()); 
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
