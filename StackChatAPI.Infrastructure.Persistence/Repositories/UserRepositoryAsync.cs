using StackChatAPI.Application.Interfaces.Repositories;
using StackChatAPI.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackChatAPI.Infrastructure.Persistence.Repositories
{
    public class UserRepositoryAsync : GenericRepositoryAsync<User>, IUserRepositoryAsync
    {
        private readonly DbSet<User> _user;

        public UserRepositoryAsync(StackChatContext dbContext) : base(dbContext)
        {
            _user = dbContext.Set<User>();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _user.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByNameOrEmail(string searchString)
        {
            return await _user.Where(u => 
                (u.FirstName + u.LastName).Contains(searchString) ||
                u.Email.Contains(searchString)
                ).ToListAsync();
        }
    }
}
