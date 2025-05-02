using Common.Models;
using MediatR;

namespace Application.Commands.Admin
{
  public class UpdateUserCommand : IRequest<ResponseModel<string>>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
