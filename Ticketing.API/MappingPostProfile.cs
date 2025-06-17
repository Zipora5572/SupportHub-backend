using AutoMapper;
using Ticketing.API.PostModel;
using Ticketing.Core.DTOs;

namespace Ticketing.API
{
    public class MappingPostProfile : Profile
    {
        public MappingPostProfile()
        {
            CreateMap<UserPostModel, UserDto>();
            CreateMap<TicketPostModel, TicketDto>();
        }
    }
}
