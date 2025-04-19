
using Application.Interfaces.IRepositories;
using AutoMapper;
using Common.DTOs.User;
using Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usecases.Users
{
    public class GetAllUsers
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsers(IGenericRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> ExecuteAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }
    }
}
