using StackChatAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StackChatAPI.Domain.DataModels
{
    public class Message
    {
        public Message()
        {
            this.Id = Guid.NewGuid();
            this.Date = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public MessageType Type { get; set; }
        public string MessageContent { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
    }
}