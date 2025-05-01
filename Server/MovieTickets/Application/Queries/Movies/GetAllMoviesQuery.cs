using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs.City;
using Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Movies
{
    public class GetAllMoviesQuery : IRequest<ResponseModel<IEnumerable<Movie>>>
    {
    }
}
