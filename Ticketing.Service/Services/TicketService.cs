using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ticketing.Core.DTOs;
using Ticketing.Core.Entities;
using Ticketing.Core.Enums;
using Ticketing.Core.IServices;
using Ticketing.Core.Models;
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

        public async Task<PagedResult<TicketDto>> GetAllAsync(TicketFilter filter)
        {
            IQueryable<Ticket> query = _repo.Tickets.GetAll();

            if (filter.Status.HasValue)
                query = query.Where(t => t.Status == filter.Status.Value);

            if (filter.Category.HasValue)
                query = query.Where(t => t.Category == filter.Category.Value);

            if (filter.Priority.HasValue)
                query = query.Where(t => t.Priority == filter.Priority.Value);

            if (filter.CreatedByUserId.HasValue)
                query = query.Where(t => t.CreatedByUserId == filter.CreatedByUserId.Value);

            if (filter.AssignedToUserId.HasValue)
                query = query.Where(t => t.AssignedToUserId == filter.AssignedToUserId.Value);

            if (filter.DueDateFrom.HasValue)
                query = query.Where(t => t.DueDate >= filter.DueDateFrom.Value);

            if (filter.DueDateTo.HasValue)
                query = query.Where(t => t.DueDate <= filter.DueDateTo.Value);

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            var dtos = _mapper.Map<IEnumerable<TicketDto>>(items);

            return new PagedResult<TicketDto>(
                Items: dtos,
                TotalCount: totalCount,
                PageSize: filter.PageSize,
                CurrentPage: filter.Page
            );
        }

        public async Task<TicketDto> GetByIdAsync(int id)
        {
            var entity = await _repo.Tickets.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<TicketDto>(entity);
        }

        public async Task<TicketDto> CreateAsync(TicketDto dto)
        {
            var entity = _mapper.Map<Ticket>(dto);
            await _repo.Tickets.AddAsync(entity);
            await _repo.SaveAsync();
            return _mapper.Map<TicketDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, TicketDto dto)
        {
            var existing = await _repo.Tickets.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repo.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.Tickets.GetByIdAsync(id);
            if (existing == null) return false;
            await _repo.Tickets.DeleteAsync(existing);
            await _repo.SaveAsync();
            return true;
        }

        public async Task<bool> ChangeStatusAsync(int id, TicketStatus status)
        {
            var existing = await _repo.Tickets.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Status = status;
            existing.LastActivity = DateTime.UtcNow;

            await _repo.SaveAsync();
            return true;
        }

        public async Task<bool> AssignTicketAsync(int id, int? assignedToUserId)
        {
            var existing = await _repo.Tickets.GetByIdAsync(id);
            if (existing == null) return false;

            existing.AssignedToUserId = assignedToUserId;
            existing.LastActivity = DateTime.UtcNow;

            await _repo.SaveAsync();
            return true;
        }
    }

}
