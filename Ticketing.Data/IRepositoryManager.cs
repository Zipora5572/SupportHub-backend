using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.IRepositories;
using Ticketing.Data.Repositories;

namespace Ticketing.Data
{
    public interface IRepositoryManager
    {
        IUserRepository Users { get; }
        ITicketRepository Tickets { get; }
       
        Task SaveAsync();
    }
}
