using Application.Interfaces;
using Domain.Entities;
using Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IGenericRepository<Movie> _genericRepository;

        public MovieRepository(IGenericRepository<Movie> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByTitleAsync(string title)
        {
            return await _genericRepository.FindAsync(m => m.MovieName.Contains(title, StringComparison.OrdinalIgnoreCase));
        }
    }
}
