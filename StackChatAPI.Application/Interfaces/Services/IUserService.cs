using StackChatAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackChatAPI.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersByNameOrEmail(string searchString);
        Task UpdateUserConnectionId(Guid id, string connectionId);
    }
}
