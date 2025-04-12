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
    public class UserRepository : IUserRepository
    {
        private readonly IGenericRepository<User> _genericRepository;

        public UserRepository(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _genericRepository.GetAllAsync();
        }
    }
}
