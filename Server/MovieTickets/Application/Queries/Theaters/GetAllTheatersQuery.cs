using Common.DTOs.Theater;
using Common.Models;
using MediatR;

namespace Application.Queries.Theaters
{
    public class GetAllTheatersQuery : IRequest<ResponseModel<IEnumerable<TheaterDTO>>>
    {
    }
}
