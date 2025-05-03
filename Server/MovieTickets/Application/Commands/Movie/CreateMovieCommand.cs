using Common.DTOs.Actor;
using Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Movie
{
    public class CreateMovieCommand : IRequest<ResponseModel<string>>
    {
        public string MovieName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsPublic { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime EndDate { get; set; }
        public IFormFile? MovieImageFile { get; set; }
        public List<ActorRoleDTO> Actors { get; set; } = new List<ActorRoleDTO>(); 
    }
}
