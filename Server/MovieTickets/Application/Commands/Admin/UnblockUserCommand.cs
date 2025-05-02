using Common.Models;
using MediatR;

namespace Application.Commands.Admin
{
    public class UnblockUserCommand : IRequest<ResponseModel<string>>
    {
        public Guid Id { get; set; }
        public bool IsBlocked { get; set; } = false;
    }
}
