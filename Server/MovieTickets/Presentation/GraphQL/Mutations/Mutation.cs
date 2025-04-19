using Application.Commands.Auth;
using Common.DTOs.User;
using Common.Models;
using MediatR;

namespace Presentation.GraphQL.Mutations
{
    public class Mutation
    {
        public async Task<ResponseModel<UserDTO>> RegisterUser(
            [Service] IMediator mediator,
            RegisterCommand command)
        {
            return await mediator.Send(command);
        }
    }
}