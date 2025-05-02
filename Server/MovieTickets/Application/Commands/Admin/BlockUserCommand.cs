using Common.Models;
using MediatR;

namespace Application.Commands.Admin
{
    public class BlockUserCommand : IRequest<ResponseModel<string>>
    {
        public Guid Id { get; set; }
        public bool IsBlocked { get; set; }
    }
}
