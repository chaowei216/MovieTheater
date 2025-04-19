using AutoMapper;
using Common.DTOs.City;
using Common.DTOs.Movie;
using Common.DTOs.Role;
using Common.DTOs.Room;
using Common.DTOs.Showtime;
using Common.DTOs.Theater;
using Common.DTOs.Ticket;
using Common.DTOs.Transaction;
using Common.DTOs.User;
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
