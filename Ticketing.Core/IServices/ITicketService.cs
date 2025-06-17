using System.Threading.Tasks;
using System.Collections.Generic;
using Ticketing.Core.DTOs;
using Ticketing.Core.Enums;
using Ticketing.Core.Models;

namespace Ticketing.Core.IServices
{
    public interface ITicketService
    {
        Task<PagedResult<TicketDto>> GetAllAsync(TicketFilter filter);
        Task<TicketDto> GetByIdAsync(int id);
        Task<TicketDto> CreateAsync(TicketDto dto);
        Task<bool> UpdateAsync(int id, TicketDto dto);
        Task<bool> DeleteAsync(int id);

       
        Task<bool> ChangeStatusAsync(int id, TicketStatus status);

        Task<bool> AssignTicketAsync(int id, int? assignedToUserId);
    }
}
