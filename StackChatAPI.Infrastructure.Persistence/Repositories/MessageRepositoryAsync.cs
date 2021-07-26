using StackChatAPI.Application.Interfaces.Repositories;
using StackChatAPI.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace StackChatAPI.Infrastructure.Persistence.Repositories
{
    public class MessageRepositoryAsync : GenericRepositoryAsync<Message>, IMessageRepositoryAsync
    {
        private readonly DbSet<Message> _messages;

        public MessageRepositoryAsync(StackChatContext dbContext) : base(dbContext)
        {
            _messages = dbContext.Set<Message>();
        }

        public async Task<IEnumerable<Message>> GetPagedMessages(int pageNumber, int pageSize)
        {
            return await _messages
                .OrderByDescending(m => m.Date)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
