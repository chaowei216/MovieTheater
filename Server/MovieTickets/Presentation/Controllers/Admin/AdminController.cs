using Application.Commands.Admin;
using Application.Queries.Users;
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
    }
}


