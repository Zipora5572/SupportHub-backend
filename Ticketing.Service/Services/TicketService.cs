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
    public class TicketService : ITicketService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public TicketService(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<TicketDto> GetByIdAsync(int id)
        {
            var entity = await _repo.Tickets.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<TicketDto>(entity);
        }

        public async Task<TicketDto> CreateAsync(TicketDto dto)
        {
            var entity = _mapper.Map<Ticket>(dto);
            await  _repo.Tickets.AddAsync(entity);
            await _repo.SaveAsync();
            return _mapper.Map<TicketDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, TicketDto dto)
        {
            var existing = await  _repo.Tickets.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repo.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await  _repo.Tickets.GetByIdAsync(id);
            if (existing == null) return false;
             _repo.Tickets.DeleteAsync(existing);
            await _repo.SaveAsync();
            return true;
        }
    }

}
