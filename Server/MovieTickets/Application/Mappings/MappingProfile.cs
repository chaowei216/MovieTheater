using AutoMapper;
using Common.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDTO>();
            CreateMap<Movie, MovieDTO>();
            CreateMap<Role, RoleDTO>();
            CreateMap<Room, RoomDTO>();
            CreateMap<Showtime, ShowtimeDTO>();
            CreateMap<Theater, TheaterDTO>();
            CreateMap<Ticket, TicketDTO>();
            CreateMap<Transaction, TransactionDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}
