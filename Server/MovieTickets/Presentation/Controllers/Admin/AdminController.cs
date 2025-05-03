using Application.Commands.Admin;
using Application.Commands.Movie;
using Application.Queries.Movies;
using Application.Queries.Users;
using Common.DTOs.Actor;
using Common.DTOs.Movie;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Admin
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Create a new Staff
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("users")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(new { result.Success, result.Message });
            }
            return CreatedAtAction(nameof(GetUserById), new { id = result.Data }, new { result.Success, result.Message, UserId = result.Data });
        }
        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("users")]
        public async Task<IActionResult> UpdateUser( [FromBody] UpdateUserCommand command)
        {
           
            var result = await _mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(new { result.Success, result.Message });
            }
            return Ok(new { result.Success, result.Message, UserId = result.Data });
        }
        /// <summary>
        /// Block a user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("users/block")]
        public async Task<IActionResult> BlockUser([FromBody] BlockUserCommand command)
        {
            

            
            var result = await _mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(new { result.Success, result.Message });
            }
            return Ok(new { result.Success, result.Message, UserId = result.Data });
        }
        /// <summary>
        /// Unblock a user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPatch("users/unblock")]
        public async Task<IActionResult> UnblockUser([FromBody] BlockUserCommand command)
        {



            var result = await _mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(new { result.Success, result.Message });
            }
            return Ok(new { result.Success, result.Message, UserId = result.Data });
        }

        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new { Success = false, Message = "Invalid user ID", ErrorCode = "INVALID_USER_ID" });
            }

            var query = new GetUserByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (!result.Success)
            {
                return BadRequest(new { result.Success, result.Message });
            }
            return Ok(result.Data);
        }
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            if (!result.Success)
            {
                return BadRequest(new { result.Success, result.Message });
            }
            return Ok(result.Data);
        }
        /// <summary>
        /// Create a new movie
        /// </summary>
        /// <param name="movieName"></param>
        /// <param name="description"></param>
        /// <param name="isPublic"></param>
        /// <param name="duration"></param>
        /// <param name="releaseDate"></param>
        /// <param name="endDate"></param>
        /// <param name="movieImageFile"></param>
        /// <param name="actorNames"></param>
        /// <param name="actorDescriptions"></param>
        /// <param name="sexes"></param>
        /// <param name="datesOfBirth"></param>
        /// <param name="characterNames"></param>
        /// <param name="actorImageFiles"></param>
        /// <returns></returns>
        [HttpPost("movies")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateMovie([FromForm] CreateMovieRequest request)
        {
          
            int actorCount = request.ActorNames.Count;
            if (actorCount == 0)
            {
                return BadRequest(new { Success = false, Message = "At least one actor is required." });
            }

            if (request.CharacterNames.Count != actorCount ||
                (request.ActorDescriptions != null && request.ActorDescriptions.Count != actorCount) ||
                (request.Sexes != null && request.Sexes.Count != actorCount) ||
                (request.DatesOfBirth != null && request.DatesOfBirth.Count != actorCount) ||
                (request.ActorImageFiles != null && request.ActorImageFiles.Count != actorCount))
            {
                return BadRequest(new { Success = false, Message = "Mismatch in the number of actor details." });
            }

          
            var command = new CreateMovieCommand
            {
                MovieName = request.MovieName,
                Description = request.Description,
                IsPublic = request.IsPublic,
                Duration = request.Duration,
                ReleaseDate = request.ReleaseDate,
                EndDate = request.EndDate,
                MovieImageFile = request.MovieImageFile,
                Actors = new List<ActorRoleDTO>()
            };


            for (int i = 0; i < actorCount; i++)
            {
                var actor = new ActorRoleDTO
                {
                    ActorName = request.ActorNames[i],
                    ActorDescription = request.ActorDescriptions?.Count > i ? request.ActorDescriptions[i] : null,
                    Sex = request.Sexes?.Count > i ? request.Sexes[i] : null,
                    DateOfBirth = request.DatesOfBirth?.Count > i ? request.DatesOfBirth[i] : null,
                    CharacterName = request.CharacterNames[i],
                    ActorImageFile = request.ActorImageFiles?.Count > i ? request.ActorImageFiles[i] : null
                };
                command.Actors.Add(actor);
            }

            var result = await _mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(new { result.Success, result.Message });
            }
            return CreatedAtAction(nameof(GetMovieById), new { id = result.Data }, new { result.Success, result.Message, MovieId = result.Data });
        }
        /// <summary>
        /// Get Movie by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("movies/{id}")]
        public async Task<IActionResult> GetMovieById(Guid id)
        {
            var query = new GetMovieByIdQuery { Id = id }; 
            var result = await _mediator.Send(query);
            if (!result.Success)
            {
                return NotFound(new { result.Success, result.Message });
            }
            return Ok(result.Data);
        }
    }
}


