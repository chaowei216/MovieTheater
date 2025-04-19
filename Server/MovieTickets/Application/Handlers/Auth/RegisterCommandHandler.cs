using Application.Commands.Auth;
using AutoMapper;
using Common.DTOs.User;
using Common.Models;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Auth
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ResponseModel<UserDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly ILocalizer _localizer;
        private readonly ILogger<RegisterCommandHandler> _logger;

        public RegisterCommandHandler(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IPasswordHasher passwordHasher,
            IMapper mapper,
            ILocalizer localizer,
            ILogger<RegisterCommandHandler> logger)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ResponseModel<UserDTO>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Processing registration for username: {Username}", request.Username);

            // Validate RoleId
            var role = await _roleRepository.GetByIdAsync(request.RoleId);
            if (role == null)
            {
                _logger.LogWarning("Registration failed: Role {RoleId} not found", request.RoleId);
                return new ResponseModel<UserDTO>
                {
                    Success = false,
                    Message = _localizer.GetString("InvalidRole"),
                    Data = null
                };
            }

            // Check if username or email already exists
            var existingUser = await _userRepository.GetByUsernameAsync(request.Username);
            if (existingUser != null)
            {
                _logger.LogWarning("Registration failed: Username {Username} already exists", request.Username);
                return new ResponseModel<UserDTO>
                {
                    Success = false,
                    Message = _localizer.GetString("UsernameExists"),
                    Data = null
                };
            }

            var existingEmail = await _userRepository.GetByEmailAsync(request.Email);
            if (existingEmail != null)
            {
                _logger.LogWarning("Registration failed: Email {Email} already exists", request.Email);
                return new ResponseModel<UserDTO>
                {
                    Success = false,
                    Message = _localizer.GetString("EmailExists"),
                    Data = null
                };
            }

            // Hash password with salt
            var (hash, salt) = _passwordHasher.HashPassword(request.Password);

            // Create new user
            var user = new User
            {
                UserName = request.Username,
                Email = request.Email,
                Phone = request.Phone,
                PasswordHash = hash,
                PasswordSalt = salt,
                RoleId = request.RoleId,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            _logger.LogInformation("Registration successful for username: {Username}", request.Username);

            return new ResponseModel<UserDTO>
            {
                Success = true,
                Message = _localizer.GetString("RegistrationSuccess"),
                Data = _mapper.Map<UserDTO>(user)
            };
        }
    }
}
