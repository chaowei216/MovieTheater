using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.Queries.Movies
{
    public class GetMovieByIdQuery : IRequest<ResponseModel<Movie>>
    {
        public Guid Id { get; set; }
    }
}
