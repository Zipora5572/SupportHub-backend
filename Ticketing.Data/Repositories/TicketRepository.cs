using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;
using Ticketing.Core.IRepositories;

namespace Ticketing.Data.Repositories
{
    public class TicketRepository:Repository<Ticket>,ITicketRepository
    {
        readonly IDataContext _context;
        public TicketRepository(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
