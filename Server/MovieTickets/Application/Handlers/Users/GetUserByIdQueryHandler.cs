using Application.Commands.Auth;
using Application.Queries.Users;
using AutoMapper;
using Common.DTOs.User;
using Common.Models;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Users
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResponseModel<UserDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;
        private readonly ILogger<GetUserByIdQueryHandler> _logger;

        public GetUserByIdQueryHandler(
            IUserRepository userRepository,
            IMapper mapper,
            ILocalizer localizer,
            ILogger<GetUserByIdQueryHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _localizer = localizer;
            _logger = logger;
        }

        public async Task<ResponseModel<UserDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Retrieving user with ID: {UserId}", request.Id);

                if (request.Id == Guid.Empty)
                {
                    return new ResponseModel<UserDTO>
                    {
                        Success = false,
                        Message = _localizer.GetString("InvalidUserId"),

                    };
                }


                var user = await _userRepository.GetByIdAsync(request.Id);
                if (user == null)
                {
                    return new ResponseModel<UserDTO>
                    {
                        Success = false,
                        Message = _localizer.GetString("UserNotFound"),

                    };
                }

                var userDto = _mapper.Map<UserDTO>(user);

                _logger.LogInformation("User {UserId} retrieved successfully", request.Id);

                return new ResponseModel<UserDTO>
                {
                    Success = true,
                    Message = _localizer.GetString("UserRetrieved"),
                    Data = userDto
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user with ID: {UserId}", request.Id);
                return new ResponseModel<UserDTO>
                {
                    Success = false,
                    Message = _localizer.GetString("UnexpectedError"),

                };
            }
        }
    }
}
