using Application.Commands.Admin;
using Application.Commands.Auth;
using Common.Models;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseModel<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILocalizer _localizer;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IPasswordHasher passwordHasher,
            ILocalizer localizer,
            ILogger<CreateUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
            _localizer = localizer;
            _logger = logger;
        }

        public async Task<ResponseModel<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Creating user with username: {UserName}", request.UserName);


                if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResponseModel<string>
                    {
                        Success = false,
                        Message = _localizer.GetString("InvalidInput"),

                    };
                }


                var existingUser = await _userRepository.GetByUsernameAsync(request.UserName);
                if (existingUser != null)
                {
                    return new ResponseModel<string>
                    {
                        Success = false,
                        Message = _localizer.GetString("UsernameExists"),

                    };
                }

                var existingEmail = await _userRepository.GetByEmailAsync(request.Email);
                if (existingEmail != null)
                {
                    return new ResponseModel<string>
                    {
                        Success = false,
                        Message = _localizer.GetString("EmailExists"),

                    };
                }


                var role = await _roleRepository.GetByNameAsync("Staff Manager");
                if (role == null)
                {
                    return new ResponseModel<string>
                    {
                        Success = false,
                        Message = _localizer.GetString("RoleNotFound"),

                    };
                }


                var defaultPassword = "12345";
                var (passwordHash, salt) = _passwordHasher.HashPassword(defaultPassword);


                var user = new User
                {
                    Id = Guid.NewGuid(),
                    UserName = request.UserName,
                    Email = request.Email,
                    Phone = request.Phone,
                    PasswordHash = passwordHash,
                    PasswordSalt = salt,
                    RoleId = role.Id,
                    IsBlocked = false,
                    CreatedAt = DateTime.UtcNow

                };

                await _userRepository.AddAsync(user);

                _logger.LogInformation("User {UserName} created successfully", request.UserName);

                return new ResponseModel<string>
                {
                    Success = true,
                    Message = _localizer.GetString("UserCreated"),
                    Data = user.Id.ToString()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user with username: {UserName}", request.UserName);
                return new ResponseModel<string>
                {
                    Success = false,
                    Message = _localizer.GetString("UnexpectedError"),

                };
            }
        }
    }
}
