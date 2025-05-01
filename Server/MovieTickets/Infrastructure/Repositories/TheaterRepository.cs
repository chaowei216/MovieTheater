using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TheaterRepository : ITheaterRepository
    {
        private readonly MovieDbContext _context;
        public TheaterRepository(MovieDbContext context)
        {
            _context = context;
        }
        public Task<Theater?> GetByIdAsync(Guid theaterId)
        {
            return _context.Theaters
                .FirstOrDefaultAsync(t => t.Id == theaterId);
        }
    }
}
