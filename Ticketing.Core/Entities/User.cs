using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Core.Entities
{
        public class User
        {
            public int UserId { get; set; }
            public string FullName { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;

            public List<Ticket> CreatedTickets { get; set; } = new();
            public List<Ticket> AssignedTickets { get; set; } = new();
        }
    


}
