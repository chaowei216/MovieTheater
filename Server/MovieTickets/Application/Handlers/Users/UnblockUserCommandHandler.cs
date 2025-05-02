using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.Admin;
using Application.Commands.Auth;
using Common.Models;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Users
{
    public class UnblockUserCommandHandler : IRequestHandler<UnblockUserCommand, ResponseModel<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILocalizer _localizer;
        private readonly ILogger<UnblockUserCommandHandler> _logger;

        public UnblockUserCommandHandler(
            IUserRepository userRepository,
            ILocalizer localizer,
            ILogger<UnblockUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _localizer = localizer;
            _logger = logger;
        }

        public async Task<ResponseModel<string>> Handle(UnblockUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Unblocking user with ID: {UserId}, IsBlocked: {IsBlocked}", request.Id, request.IsBlocked);


                if (request.Id == Guid.Empty)
                {
                    return new ResponseModel<string>
                    {
                        Success = false,
                        Message = _localizer.GetString("InvalidUserId"),

                    };
                }


                var user = await _userRepository.GetByIdAsync(request.Id);
                if (user == null)
                {
                    return new ResponseModel<string>
                    {
                        Success = false,
                        Message = _localizer.GetString("UserNotFound"),

                    };
                }


                user.IsBlocked = request.IsBlocked;
                user.UpdatedAt = DateTime.UtcNow;

                await _userRepository.UpdateAsync(user);

                _logger.LogInformation("User {UserId} block status updated to {IsBlocked}", request.Id, request.IsBlocked);

                return new ResponseModel<string>
                {
                    Success = true,
                    Message = request.IsBlocked ? _localizer.GetString("UserUnblocked") : _localizer.GetString("UserUnblocked"),
                    Data = user.Id.ToString()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error blocking user with ID: {UserId}", request.Id);
                return new ResponseModel<string>
                {
                    Success = false,
                    Message = _localizer.GetString("UnexpectedError"),

                };
            }
        }
    }
}
