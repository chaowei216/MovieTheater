using Application.Commands.Auth;
using Application.Interfaces.AuthService;
using Application.Interfaces.IRepositories;
using Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Auth
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, ResponseModel<LoginResponse>>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IRefreshTokenService _refreshTokenService; 
        private readonly ILocalizer _localizer;
        private readonly ILogger<RefreshTokenCommandHandler> _logger;

        public RefreshTokenCommandHandler(
            IRefreshTokenRepository refreshTokenRepository,
            IJwtTokenService jwtTokenService,
            IRefreshTokenService refreshTokenService,
            ILocalizer localizer,
            ILogger<RefreshTokenCommandHandler> logger)
        {
            _refreshTokenRepository = refreshTokenRepository ?? throw new ArgumentNullException(nameof(refreshTokenRepository));
            _jwtTokenService = jwtTokenService ?? throw new ArgumentNullException(nameof(jwtTokenService));
            _refreshTokenService = refreshTokenService ?? throw new ArgumentNullException(nameof(refreshTokenService));
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ResponseModel<LoginResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Processing refresh token request.");

            var refreshToken = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken);
            if (refreshToken == null)
            {
                _logger.LogWarning("Refresh token invalid or expired.");
                return new ResponseModel<LoginResponse>
                {
                    Success = false,
                    Message = _localizer.GetString("InvalidRefreshToken"),
                    Data = null
                };
            }

            refreshToken.IsRevoked = true;
            await _refreshTokenRepository.UpdateAsync(refreshToken);

            var newAccessToken = _jwtTokenService.GenerateToken(refreshToken.User);
            var newRefreshToken = _refreshTokenService.GenerateRefreshToken(refreshToken.User);
            await _refreshTokenRepository.AddAsync(newRefreshToken);

            _logger.LogInformation("Refresh token successful for user: {UserId}", refreshToken.UserId);

            return new ResponseModel<LoginResponse>
            {
                Success = true,
                Message = _localizer.GetString("RefreshTokenSuccess"),
                Data = new LoginResponse
                {
                    Token = newAccessToken,
                    RefreshToken = newRefreshToken.Token,
                    UserName = refreshToken.User.UserName,
               
                }
            };
        }
    }
}
