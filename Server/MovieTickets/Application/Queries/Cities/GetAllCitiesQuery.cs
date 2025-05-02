using Common.DTOs.City;
using Common.Models;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Cities
{
    public class GetAllCitiesQuery : IRequest<ResponseModel<IEnumerable<City>>>
    {
    }
}
