using AutoMapper;
using StackChatAPI.Domain.DataModels;
using StackChatAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
