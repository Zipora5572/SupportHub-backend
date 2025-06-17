using System;
using Ticketing.Core.Enums;

namespace Ticketing.Core.Models
{
    public record TicketFilter(
        TicketStatus? Status = null,
        TicketCategory? Category = null,
        TicketPriority? Priority = null,
        int? CreatedByUserId = null,
        int? AssignedToUserId = null,
        DateTime? DueDateFrom = null,
        DateTime? DueDateTo = null,
        int Page = 1,
        int PageSize = 20
    );
}
