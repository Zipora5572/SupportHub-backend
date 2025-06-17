using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;
using Ticketing.Core.IRepositories;

namespace Ticketing.Data.Repositories
{  
    public class UserRepository : Repository<User>, IUserRepository
    { 
        readonly IDataContext _context;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

    }
}
