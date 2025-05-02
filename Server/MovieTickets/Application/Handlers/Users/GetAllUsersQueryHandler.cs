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
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResponseModel<List<UserDTO>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;
        private readonly ILogger<GetAllUsersQueryHandler> _logger;

        public GetAllUsersQueryHandler(
            IUserRepository userRepository,
            IMapper mapper,
            ILocalizer localizer,
            ILogger<GetAllUsersQueryHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _localizer = localizer;
            _logger = logger;
        }

        public async Task<ResponseModel<List<UserDTO>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Retrieving all users");

                var users = await _userRepository.GetAllAsync();
                var userDtos = _mapper.Map<List<UserDTO>>(users);

                _logger.LogInformation("Retrieved {UserCount} users", userDtos.Count);

                return new ResponseModel<List<UserDTO>>
                {
                    Success = true,
                    Message = _localizer.GetString("UsersRetrieved"),
                    Data = userDtos
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all users");
                return new ResponseModel<List<UserDTO>>
                {
                    Success = false,
                    Message = _localizer.GetString("UnexpectedError"),

                };
            }
        }
    }
}
