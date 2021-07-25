using AutoMapper;
using StackChatAPI.Domain.DataModels;
using StackChatAPI.Domain.DTOs;

namespace StackChatAPI.Domain.AutoMapper
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Message, MessageDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
