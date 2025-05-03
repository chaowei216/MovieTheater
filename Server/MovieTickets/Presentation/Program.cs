using System.Reflection;
using Application;
using CloudinaryDotNet;
using Infrastructure;
using Infrastructure.Configurations;
using Microsoft.OpenApi.Models;
using MovieTickets.Presentation.GraphQL.Queries;
using Presentation.GraphQL.Mutations;
using Presentation.Middlewares;
using Serilog;

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
                builder.Services.Configure<CloudinarySettings>(
                builder.Configuration.GetSection("Cloudinary"));


                builder.Services.AddSingleton<Cloudinary>(provider =>
                {
                    var config = provider.GetRequiredService<IConfiguration>()
                        .GetSection("Cloudinary").Get<CloudinarySettings>();
                    if (string.IsNullOrEmpty(config.CloudName) || string.IsNullOrEmpty(config.ApiKey) || string.IsNullOrEmpty(config.ApiSecret))
                    {
                        throw new InvalidOperationException("Cloudinary configuration is missing or invalid.");
                    }
                    var account = new Account(config.CloudName, config.ApiKey, config.ApiSecret);
                    return new Cloudinary(account);
                });
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


                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Input Token. Example: Bearer {token}"
                    });


                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
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
