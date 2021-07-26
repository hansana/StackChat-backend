using StackChatAPI.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackChatAPI.Application.Interfaces.Repositories
{
    public interface IMessageRepositoryAsync : IGenericRepositoryAsync<Message>
    {
        Task<IEnumerable<Message>> GetPagedMessages(int pageNumber, int pageSize);
    }
}
