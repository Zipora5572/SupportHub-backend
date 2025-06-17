using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.IRepositories;
using Ticketing.Data.Repositories;

namespace Ticketing.Data
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IDataContext _context;

        public IUserRepository Users { get; }
        public ITicketRepository Tickets { get; }




        public RepositoryManager(
        IDataContext context,
            IUserRepository userRepository,
            ITicketRepository ticketRepository
           )
        {
            _context = context;
            Users = userRepository;
            Tickets = ticketRepository;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
