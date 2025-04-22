using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MovieDbContext _context;

        public RoleRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<Role?> GetByIdAsync(Guid roleId)
        {
            return await _context.Roles
                .FirstOrDefaultAsync(r => r.Id == roleId);
        }
    }
}
