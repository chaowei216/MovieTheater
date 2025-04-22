using Application.Queries.City;
using Application.Usecases.Cities;
using Common.DTOs.City;
using Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.City
{
    public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, ResponseModel<IEnumerable<CityDTO>>>
    {
        private readonly GetAllCities _useCase;

        public GetAllCitiesQueryHandler(GetAllCities useCase)
        {
            _useCase = useCase;
        }

        public async Task<ResponseModel<IEnumerable<CityDTO>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            return await _useCase.Handle(request, cancellationToken);
        }
    }

}
