using Application.Commands.Auth;
using Application.Interfaces;
using Application.Interfaces.AuthService;
using Application.Interfaces.IRepositories;
using Common.Models;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Auth
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseModel<LoginResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly ILocalizer _localizer;
        private readonly ILogger<LoginCommandHandler> _logger;

        public LoginCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IJwtTokenService jwtTokenService,
            IRefreshTokenRepository refreshTokenRepository,
            IRefreshTokenService refreshTokenService,
            ILocalizer localizer,
            ILogger<LoginCommandHandler> logger)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
            _jwtTokenService = jwtTokenService ?? throw new ArgumentNullException(nameof(jwtTokenService));
            _refreshTokenRepository = refreshTokenRepository ?? throw new ArgumentNullException(nameof(refreshTokenRepository));
            _refreshTokenService = refreshTokenService ?? throw new ArgumentNullException(nameof(refreshTokenService));
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        } 

        public async Task<ResponseModel<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Processing login for username: {Username}", request.Email);

        
                _logger.LogDebug("Attempting to retrieve user with username: {Username}", request.Email);
                var user = await _userRepository.GetByEmailAsync(request.Email);
                if (user == null)
                {
                    _logger.LogWarning("Login failed: User {Username} not found", request.Email);
                    return new ResponseModel<LoginResponse>
                    {
                        Success = false,
                        Message = _localizer.GetString("UserNotFound"),
                        Data = null
                    };
                }
                _logger.LogDebug("User {Username} found with ID: {UserId}", request.Email, user.Id);

          
                _logger.LogDebug("Verifying password for user: {Username}", request.Email);
                if (!_passwordHasher.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    _logger.LogWarning("Login failed: Invalid password for username {Username}", request.Email);
                    return new ResponseModel<LoginResponse>
                    {
                        Success = false,
                        Message = _localizer.GetString("InvalidPassword"),
                        Data = null
                    };
                }
                _logger.LogDebug("Password verified successfully for user: {Username}", request.Email);

                _logger.LogDebug("Generating JWT token for user: {Username}", request.Email);
                var token = _jwtTokenService.GenerateToken(user);
                _logger.LogDebug("JWT token generated successfully for user: {Username}", request.Email);

                _logger.LogDebug("Generating refresh token for user: {Username}", request.Email);
                var refreshToken = _refreshTokenService.GenerateRefreshToken(user);
                _logger.LogDebug("Refresh token generated successfully for user: {Username}", request.Email);


                _logger.LogDebug("Saving refresh token for user: {Username}", request.Email);
                await _refreshTokenRepository.AddAsync(refreshToken);
                _logger.LogDebug("Refresh token saved successfully for user: {Username}", request.Email);

                _logger.LogInformation("Login successful for username: {Username}", request.Email);

                return new ResponseModel<LoginResponse>
                {
                    Success = true,
                    Message = _localizer.GetString("LoginSuccess"),
                    Data = new LoginResponse
                    {
                        Token = token,
                        RefreshToken = refreshToken.Token,
                        UserName = user.UserName,

                    }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing login for username: {Username}", request.Email);
                throw; 
            }
        }
    }
}