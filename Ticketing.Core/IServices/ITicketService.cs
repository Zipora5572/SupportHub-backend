using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.DTOs;

namespace Ticketing.Core.IServices
{
    public interface ITicketService
    {
        Task<TicketDto> GetByIdAsync(int id);
        Task<TicketDto> CreateAsync(TicketDto dto);
        Task<bool> UpdateAsync(int id, TicketDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
