
using Ticketing.Core.Enums;

namespace Ticketing.API.PostModel
{
    public record TicketPostModel(
        string Title,
        string Description,
        string CustomerEmail,
        TicketStatus Status = TicketStatus.New,
        TicketPriority Priority = TicketPriority.Medium,
        TicketCategory Category = TicketCategory.General,
        string? AssignedTo = null,
        DateTime? DueDate = null,
        List<string>? Tags = null
    );
}
