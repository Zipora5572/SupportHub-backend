using Ticketing.Core.Enums;

namespace Ticketing.Core.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public TicketStatus Status { get; set; } = TicketStatus.New;
        public TicketPriority Priority { get; set; } = TicketPriority.Medium;
        public TicketCategory Category { get; set; } = TicketCategory.General;
        public DateTime? DueDate { get; set; }
        public double? ResolutionTime { get; set; }
        public int? SatisfactionRating { get; set; }
        public double? AiCategoryConfidence { get; set; }
        public DateTime? LastActivity { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; } = null!;

        public int? AssignedToUserId { get; set; }
        public User? AssignedToUser { get; set; }
    }
}
