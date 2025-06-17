using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.DTOs;
using Ticketing.Core.Entities;

namespace Ticketing.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Ticket, TicketDto>().ReverseMap();
        }       
    }
}
