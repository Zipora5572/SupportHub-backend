using Ticketing.Core.Enums;

namespace Ticketing.Core.DTOs
{
    public record TicketDto(
        int Id,
        string Title,
        string Description,
        string CustomerEmail,
        TicketStatus Status,
        TicketPriority Priority,
        TicketCategory Category,
        string? AssignedTo,
        DateTime? DueDate,
        double? ResolutionTime,
        int? SatisfactionRating,
        List<string>? Tags,
        double? AiCategoryConfidence,
        DateTime? LastActivity
    );
}
