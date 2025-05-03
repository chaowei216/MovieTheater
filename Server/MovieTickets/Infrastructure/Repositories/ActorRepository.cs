using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        private readonly MovieDbContext _context;

        public ActorRepository(MovieDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
