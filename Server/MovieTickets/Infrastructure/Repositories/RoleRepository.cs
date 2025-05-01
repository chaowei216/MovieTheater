using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
        public async Task<Role?> GetByNameAsync(string roleName)
        {
            return await _context.Roles
                .FirstOrDefaultAsync(r => r.RoleName == roleName);
        }
    }
}
