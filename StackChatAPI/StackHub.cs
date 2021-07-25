using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using StackChatAPI.Domain.DataModels;
using StackChatAPI.Domain.DTOs;
using StackChatAPI.Domain.Enums;
using StackChatAPI.Infrastructure.Persistence;
using StackChatAPI.SignalR;
using System;

namespace StackChatAPI
{
    [HubName("StackHub")]
    public class StackHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public void BroadcastMessage(MessageDto message)
        {
            Clients.All.messageReceived(message);
        }

        public void SendMessageToClient(MessageDto message)
        {
            using (var db = new StackChatContext())
            {
                var msg = new Message()
                {
                    Id = Guid.NewGuid(),
                    UserId = message.userId,
                    Username = message.userName,
                    Type = MessageType.TextMessage,
                    MessageContent = message.message,
                    Date = DateTime.UtcNow
                };

                db.Entry(msg).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();                
            }

            Clients.Others.messageReceived(message);
        }
    }
}