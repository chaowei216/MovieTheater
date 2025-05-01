using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly MovieDbContext _context;

        public RefreshTokenRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            return await _context.RefreshTokens
                .Include(rt => rt.User)
                .FirstOrDefaultAsync(rt => rt.Token == token && !rt.IsRevoked && rt.ExpiresAt > DateTime.UtcNow);
        }

        public async Task AddAsync(RefreshToken refreshToken)
        {
            try
            {
                await _context.RefreshTokens.AddAsync(refreshToken);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Serilog.Log.Error(ex, "Failed to add refresh token for user: {UserId}", refreshToken.UserId);
                throw;
            }
        }

        public async Task UpdateAsync(RefreshToken refreshToken)
        {
            try
            {
                _context.RefreshTokens.Update(refreshToken);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Serilog.Log.Error(ex, "Failed to update refresh token: {Token}", refreshToken.Token);
                throw;
            }
        }
    }
}
