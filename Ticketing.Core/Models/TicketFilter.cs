using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Enums;

namespace Ticketing.Core.Models
{


    public record TicketFilter(
        TicketStatus? Status = null,
        TicketCategory? Category = null,
        int Page = 1,
        int PageSize = 20
    );

}


