using StackChatAPI.Application.Interfaces.Repositories;
using StackChatAPI.Application.Interfaces.Services;
using StackChatAPI.Application.Wrappers;
using StackChatAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackChatAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public UserService(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<IEnumerable<UserDto>> GetUsersByNameOrEmail(string searchString)
        {
            var users = await _userRepositoryAsync.GetUsersByNameOrEmail(searchString);
            List<UserDto> userDtos = new List<UserDto>();

            foreach(var user in users)
            {
                userDtos.Add(new UserDto()
                {
                    id = user.Id,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    email = user.Email,
                    connectionId = user.ConnectionId
                });
            }

            return userDtos;
        }

        public async Task UpdateUserConnectionId(Guid id, string connectionId)
        {
            var user = await _userRepositoryAsync.GetByIdAsync(id);

            if (user == null)
            {
                return;
            }

            user.ConnectionId = Guid.Parse(connectionId);
            await _userRepositoryAsync.UpdateAsync(user);
        }
    }
}
