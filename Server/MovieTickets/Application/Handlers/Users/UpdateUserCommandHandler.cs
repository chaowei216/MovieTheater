using Application.Commands.Admin;
using Application.Commands.Auth;
using Common.Models;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Users
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseModel<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILocalizer _localizer;
        private readonly ILogger<UpdateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(
            IUserRepository userRepository,
            ILocalizer localizer,
            ILogger<UpdateUserCommandHandler> logger
)
        {
            _userRepository = userRepository;
            _localizer = localizer;
            _logger = logger;

        }

        public async Task<ResponseModel<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Updating user with ID: {UserId}", request.Id);


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

                if (!string.IsNullOrWhiteSpace(request.Email) && request.Email != user.Email)
                {
                    var existingEmail = await _userRepository.GetByEmailAsync(request.Email);
                    if (existingEmail != null && existingEmail.Id != user.Id)
                    {
                        return new ResponseModel<string>
                        {
                            Success = false,
                            Message = _localizer.GetString("EmailExists"),

                        };
                    }
                }

                user.UserName = request.UserName ?? user.UserName;
                user.Email = request.Email ?? user.Email;
                user.Phone = request.Phone ?? user.Phone;
                user.UpdatedAt = DateTime.UtcNow;

                await _userRepository.UpdateAsync(user);

                _logger.LogInformation("User {UserId} updated successfully", request.Id);

                return new ResponseModel<string>
                {
                    Success = true,
                    Message = _localizer.GetString("UserUpdated"),
                    Data = user.Id.ToString()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user with ID: {UserId}", request.Id);
                return new ResponseModel<string>
                {
                    Success = false,
                    Message = _localizer.GetString("UnexpectedError"),

                };
            }
        }
    }
}
