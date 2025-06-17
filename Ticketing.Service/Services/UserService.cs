using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.DTOs;
using Ticketing.Core.Entities;
using Ticketing.Core.IServices;
using Ticketing.Data;

namespace Ticketing.Service.Services
{
  

    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var entity = await  _repo.Users.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<UserDto>(entity);
        }

        public async Task<UserDto> CreateAsync(UserDto dto)
        {
            var entity = _mapper.Map<User>(dto);
            await  _repo.Users.AddAsync(entity);
            await _repo.SaveAsync();
            return _mapper.Map<UserDto>(entity);
        }
    }

}
