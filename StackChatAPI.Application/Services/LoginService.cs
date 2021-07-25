using StackChatAPI.Application.Interfaces.Repositories;
using StackChatAPI.Application.Interfaces.Services;
using StackChatAPI.Application.Wrappers;
using StackChatAPI.Domain.DataModels;
using StackChatAPI.Domain.DTOs;
using System;
using System.Threading.Tasks;

namespace StackChatAPI.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public LoginService(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<Response<UserDto>> RegisterUser(UserDto userDto)
        {
            User user = await _userRepositoryAsync.GetUserByEmail(userDto.email);

            if (user != null)
            {
                if (user.UserName != userDto.userName)
                {
                    user.UserName = userDto.userName;
                    await _userRepositoryAsync.UpdateAsync(user);
                }

                userDto.id = user.Id;
                userDto.createdAt = user.CreatedAt;

                return new Response<UserDto>(userDto);
            }
            else
            {
                user = await _userRepositoryAsync.AddAsync(new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = userDto.firstName,
                    LastName = userDto.lastName,
                    Email = userDto.email,
                    UserName = userDto.userName,
                    CreatedAt = DateTime.UtcNow
                });


                userDto.id = user.Id;
                userDto.createdAt = user.CreatedAt;
                userDto.connectionId = user.ConnectionId;

                return new Response<UserDto>(userDto);
            }
        }
    }
}
