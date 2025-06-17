using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Core.Entities
{
   
    public record User(
            int UserId,
            string FullName,
            string Email,
            string Password
    );

}
