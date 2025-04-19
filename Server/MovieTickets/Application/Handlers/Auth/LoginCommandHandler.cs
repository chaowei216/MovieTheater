using Application.Commands.Auth;
using Application.Interfaces.AuthService;
using Common.Models;
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
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseModel<LoginResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly ILocalizer _localizer;
        private readonly ILogger<LoginCommandHandler> _logger;

        public LoginCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IJwtTokenService jwtTokenService,
            ILocalizer localizer,
            ILogger<LoginCommandHandler> logger)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
            _jwtTokenService = jwtTokenService ?? throw new ArgumentNullException(nameof(jwtTokenService));
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ResponseModel<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Processing login for username: {Username}", request.Username);

            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user == null)
            {
                _logger.LogWarning("Login failed: User {Username} not found", request.Username);
                return new ResponseModel<LoginResponse>
                {
                    Success = false,
                    Message = _localizer.GetString("UserNotFound"),
                    Data = null
                };
            }

            if (!_passwordHasher.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                _logger.LogWarning("Login failed: Invalid password for username {Username}", request.Username);
                return new ResponseModel<LoginResponse>
                {
                    Success = false,
                    Message = _localizer.GetString("InvalidPassword"),
                    Data = null
                };
            }

            var token = _jwtTokenService.GenerateToken(user);
            _logger.LogInformation("Login successful for username: {Username}", request.Username);

            return new ResponseModel<LoginResponse>
            {
                Success = true,
                Message = _localizer.GetString("LoginSuccess"),
                Data = new LoginResponse
                {
                    Token = token,
                    UserName = user.UserName,
                    RoleId = user.RoleId
                }
            };
        }
    }
}
