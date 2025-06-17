using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;

namespace Ticketing.Core.IRepositories
{
    public interface ITicketRepository:IRepository<Ticket>
    {
    }
}
