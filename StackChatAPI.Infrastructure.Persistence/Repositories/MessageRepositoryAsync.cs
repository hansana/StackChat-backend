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
    public class MessageRepositoryAsync : GenericRepositoryAsync<Message>, IMessageRepositoryAsync
    {
        private readonly DbSet<Message> _messages;

        public MessageRepositoryAsync(StackChatContext dbContext) : base(dbContext)
        {
            _messages = dbContext.Set<Message>();
        }
    }
}
