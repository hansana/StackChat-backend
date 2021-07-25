using StackChatAPI.Application.Interfaces.Repositories;
using StackChatAPI.Application.Interfaces.Services;
using StackChatAPI.Domain.DataModels;
using StackChatAPI.Domain.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackChatAPI.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepositoryAsync _messageRepositoryAsync;

        public MessageService(IMessageRepositoryAsync messageRepositoryAsync)
        {
            _messageRepositoryAsync = messageRepositoryAsync;
        }

        public async Task<IEnumerable<MessageDto>> GetAllMessages()
        {
            var messages = await _messageRepositoryAsync.GetAllAsync();
            var msgDtos = new List<MessageDto>();
            foreach (var message in messages)
            {
                msgDtos.Add(new MessageDto()
                {
                    id = message.Id,
                    userId = message.UserId,
                    userName = message.Username,
                    date = message.Date,
                    type = message.Type,
                    message = message.MessageContent
                });
            }

            msgDtos = msgDtos.OrderBy(m => m.date).ToList();

            return msgDtos;
        }

        public async Task<MessageDto> SaveMessage(MessageDto message)
        {
            await _messageRepositoryAsync.AddAsync(new Message()
            {
                UserId = message.userId,
                Username = message.userName,
                Type = message.type,
                MessageContent = message.message
            });

            return message;
        }
    }
}
