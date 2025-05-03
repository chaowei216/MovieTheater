using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class MovieActorRepository : GenericRepository<MovieActor>, IMovieActorRepository
    {
        private readonly MovieDbContext _context;
        public MovieActorRepository(MovieDbContext context) : base(context)
        {
            _context = context;
        }
    }
}