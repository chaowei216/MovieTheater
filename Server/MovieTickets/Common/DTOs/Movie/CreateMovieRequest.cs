using Microsoft.AspNetCore.Http;

namespace Common.DTOs.Movie
{
    public class CreateMovieRequest
    {
        public string MovieName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsPublic { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime EndDate { get; set; }
        public IFormFile? MovieImageFile { get; set; }


        public List<string> ActorNames { get; set; } = new List<string>();
        public List<string>? ActorDescriptions { get; set; }
        public List<string>? Sexes { get; set; }
        public List<DateTime?>? DatesOfBirth { get; set; }
        public List<string> CharacterNames { get; set; } = new List<string>();
        public List<IFormFile>? ActorImageFiles { get; set; }
    }
}
