using Application.Commands.Movie;
using Application.Interfaces.Clould;
using Application.Interfaces.IUnitOfWork;
using Common.Models;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Movies
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, ResponseModel<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ILogger<CreateMovieCommandHandler> _logger;

        public CreateMovieCommandHandler(
            IUnitOfWork unitOfWork,
            ICloudinaryService cloudinaryService,
            ILogger<CreateMovieCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _cloudinaryService = cloudinaryService ?? throw new ArgumentNullException(nameof(cloudinaryService));
            _logger = logger;
        }

        public async Task<ResponseModel<string>> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Creating movie with name: {MovieName}", request.MovieName);

         
                if (string.IsNullOrWhiteSpace(request.MovieName))
                {
                    return new ResponseModel<string> { Success = false, Message = "Movie name is required." };
                }

                if (request.Duration <= 0)
                {
                    return new ResponseModel<string> { Success = false, Message = "Duration must be greater than 0." };
                }

                if (request.ReleaseDate >= request.EndDate)
                {
                    return new ResponseModel<string> { Success = false, Message = "Release date must be before end date." };
                }

                var existingMovie = await _unitOfWork.Movies.FindAsync(m => m.MovieName == request.MovieName);
                if (existingMovie.Any())
                {
                    return new ResponseModel<string> { Success = false, Message = "Movie with this name already exists." };
                }

                var movie = new Movie
                {
                    Id = Guid.NewGuid(),
                    MovieName = request.MovieName,
                    Description = request.Description,
                    IsPublic = request.IsPublic,
                    Duration = request.Duration,
                    ReleaseDate = request.ReleaseDate,
                    EndDate = request.EndDate,
                    CreatedAt = DateTime.UtcNow
                };

                if (request.MovieImageFile != null && request.MovieImageFile.Length > 0)
                {
                    movie.MovieImage = await _cloudinaryService.UploadImageAsync(request.MovieImageFile, "movies");
                }

                await _unitOfWork.Movies.AddAsync(movie);

                var movieActors = new List<MovieActor>();
                foreach (var actorRole in request.Actors)
                {
                    if (string.IsNullOrWhiteSpace(actorRole.ActorName) || string.IsNullOrWhiteSpace(actorRole.CharacterName))
                    {
                        return new ResponseModel<string> { Success = false, Message = "Actor name and character name are required." };
                    }

                    var existingActor = (await _unitOfWork.Actors.FindAsync(a => a.ActorName == actorRole.ActorName)).FirstOrDefault();
                    Actor actor;

                    if (existingActor == null)
                    {
                        actor = new Actor
                        {
                            Id = Guid.NewGuid(),
                            ActorName = actorRole.ActorName,
                            ActorDescription = actorRole.ActorDescription,
                            Sex = actorRole.Sex,
                            DateOfBirth = actorRole.DateOfBirth,
                            CreatedAt = DateTime.UtcNow
                        };

                        if (actorRole.ActorImageFile != null && actorRole.ActorImageFile.Length > 0)
                        {
                            actor.ActorImage = await _cloudinaryService.UploadImageAsync(actorRole.ActorImageFile, "actors");
                        }

                        await _unitOfWork.Actors.AddAsync(actor);
                    }
                    else
                    {
                        actor = existingActor;

                        if (actorRole.ActorImageFile != null && actorRole.ActorImageFile.Length > 0)
                        {
                            actor.ActorImage = await _cloudinaryService.UploadImageAsync(actorRole.ActorImageFile, "actors");
                            await _unitOfWork.Actors.UpdateAsync(actor);
                        }
                    }

                    var existingMovieActor = await _unitOfWork.MovieActors.FindAsync(ma => ma.MovieId == movie.Id && ma.ActorId == actor.Id);
                    if (existingMovieActor.Any())
                    {
                        return new ResponseModel<string> { Success = false, Message = $"Actor {actor.ActorName} is already associated with this movie." };
                    }

                    var movieActor = new MovieActor
                    {
                        Id = Guid.NewGuid(),
                        MovieId = movie.Id,
                        ActorId = actor.Id,
                        CharacterName = actorRole.CharacterName,
                        CreatedAt = DateTime.UtcNow
                    };
                    movieActors.Add(movieActor);
                }

                foreach (var movieActor in movieActors)
                {
                    await _unitOfWork.MovieActors.AddAsync(movieActor);
                }

                // Lưu tất cả thay đổi vào cơ sở dữ liệu
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Movie {MovieName} created successfully with {ActorCount} actors", request.MovieName, request.Actors.Count);

                return new ResponseModel<string>
                {
                    Success = true,
                    Message = "Movie and actors created successfully.",
                    Data = movie.Id.ToString()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating movie with name: {MovieName}", request.MovieName);
                return new ResponseModel<string> { Success = false, Message = "An error occurred while creating the movie and actors: " + ex.Message };
            }
        }
    }
}