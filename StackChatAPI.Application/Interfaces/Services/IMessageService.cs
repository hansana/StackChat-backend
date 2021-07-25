using StackChatAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackChatAPI.Application.Interfaces.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDto>> GetAllMessages();
        Task<MessageDto> SaveMessage(MessageDto message);
    }
}
