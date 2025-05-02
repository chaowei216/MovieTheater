using Common.DTOs.User;
using Common.Models;
using MediatR;

namespace Application.Queries.Users
{
    public class GetUserByIdQuery : IRequest<ResponseModel<UserDTO>>
    {
        public Guid Id { get; set; }
    }

}
