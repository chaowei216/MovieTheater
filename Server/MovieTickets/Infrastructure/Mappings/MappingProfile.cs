using AutoMapper;
using Common.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDTO>();
            CreateMap<Movie, MovieDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}
