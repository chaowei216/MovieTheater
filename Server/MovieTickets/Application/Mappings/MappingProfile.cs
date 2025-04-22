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

namespace Application.Mappings
{
    public class MappingProfile : Profile
    { 
        public MappingProfile()
        {
            #region city
            CreateMap<City, CityDTO>()
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreatedAt));
            #endregion
            CreateMap<Movie, MovieDTO>()
                .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<Role, RoleDTO>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<Room, RoomDTO>()
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TheaterName, opt => opt.MapFrom(src => src.Theater != null ? src.Theater.TheaterName : null))
                .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<Showtime, ShowtimeDTO>()
                .ForMember(dest => dest.ShowtimeId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie != null ? src.Movie.MovieName : null))
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Room != null ? src.Room.RoomNumber : null))
                .ForMember(dest => dest.TheaterName, opt => opt.MapFrom(src => src.Room != null && src.Room.Theater != null ? src.Room.Theater.TheaterName : null))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Room != null && src.Room.Theater != null && src.Room.Theater.City != null ? src.Room.Theater.City.CityName : null))
                .ForMember(dest => dest.AvailableSeats, opt => opt.MapFrom(src => src.AvailableSeat))
                .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<Theater, TheaterDTO>()
                .ForMember(dest => dest.TheaterId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City != null ? src.City.CityName : null))
                .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<Ticket, TicketDTO>()
                .ForMember(dest => dest.TicketId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Showtime != null && src.Showtime.Movie != null ? src.Showtime.Movie.MovieName : null))
                .ForMember(dest => dest.ShowtimeDate, opt => opt.MapFrom(src => src.Showtime != null ? src.Showtime.ShowtimeDate : default))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.UserName : null))
                .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<Transaction, TransactionDTO>()
                .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.UserName : null))
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Ticket != null && src.Ticket.Showtime != null && src.Ticket.Showtime.Movie != null ? src.Ticket.Showtime.Movie.MovieName : null))
                .ForMember(dest => dest.ShowtimeDate, opt => opt.MapFrom(src => src.Ticket != null && src.Ticket.Showtime != null ? src.Ticket.Showtime.ShowtimeDate : default))
                .ForMember(dest => dest.SeatNumber, opt => opt.MapFrom(src => src.Ticket != null ? src.Ticket.SeatNumber : null))
                .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
