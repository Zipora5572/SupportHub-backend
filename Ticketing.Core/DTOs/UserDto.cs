using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Core.DTOs
{
    public record UserDto(
       int UserId,
       string FullName,
       string Email
   );
}
