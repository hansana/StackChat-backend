using StackChatAPI.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackChatAPI.Application.Interfaces.Repositories
{
    public interface IUserRepositoryAsync : IGenericRepositoryAsync<User>
    {
        Task<IEnumerable<User>> GetUsersByNameOrEmail(string searchString);
        Task<User> GetUserByEmail(string email);
    }
}
