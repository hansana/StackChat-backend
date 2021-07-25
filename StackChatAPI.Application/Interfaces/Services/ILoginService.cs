using StackChatAPI.Application.Wrappers;
using StackChatAPI.Domain.DataModels;
using StackChatAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackChatAPI.Application.Interfaces.Services
{
    public interface ILoginService
    {
        Task<Response<UserDto>> RegisterUser(UserDto user);
    }
}
