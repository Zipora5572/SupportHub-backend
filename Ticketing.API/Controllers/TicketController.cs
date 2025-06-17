using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Core.DTOs;
using Ticketing.Core.Enums;
using Ticketing.Core.IServices;
using Ticketing.Core.Models;

namespace Ticketing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public TicketController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<TicketDto>>> GetAll([FromQuery] TicketFilter filter)
        {
            var result = await _ticketService.GetAllAsync(filter);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDto>> GetById(int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<ActionResult<TicketDto>> Create([FromBody] TicketDto dto)
        {
            var ticket = await _ticketService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TicketDto dto)
        {
            var success = await _ticketService.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _ticketService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> ChangeStatus(int id, [FromBody] TicketStatus status)
        {
            var success = await _ticketService.ChangeStatusAsync(id, status);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPatch("{id}/assign")]
        public async Task<IActionResult> AssignTicket(int id, [FromBody] int? assignedToUserId)
        {
            var success = await _ticketService.AssignTicketAsync(id, assignedToUserId);
            if (!success) return NotFound();
            return NoContent();
        }

    }


}
