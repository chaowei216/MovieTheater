using Application.Interfaces.IUnitOfWork;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDbContext _context;
        public IMovieRepository Movies { get; }
        public IActorRepository Actors { get; }
        public IMovieActorRepository MovieActors { get; }

        public UnitOfWork(MovieDbContext context)
        {
            _context = context;
            Movies = new MovieRepository(_context);
            Actors = new ActorRepository(_context);
            MovieActors = new MovieActorRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
