using Common.Models;
using MediatR;

namespace Application.Commands.Admin
{
    public class CreateUserCommand : IRequest<ResponseModel<string>>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
    }

}

