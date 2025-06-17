using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Ticketing.Core.Entities;

namespace Ticketing.Data
{
    public interface IDataContext
    {
        DbSet<Ticket> Tickets { get; set; }
        DbSet<User> Users { get; set; }

        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
