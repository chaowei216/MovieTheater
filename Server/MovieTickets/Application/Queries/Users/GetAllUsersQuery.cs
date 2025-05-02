using Common.DTOs.User;
using Common.Models;
using MediatR;

namespace Application.Queries.Users
{
    public class GetAllUsersQuery : IRequest<ResponseModel<List<UserDTO>>>
    {

    }
}
