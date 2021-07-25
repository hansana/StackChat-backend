using StackChatAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackChatAPI.Domain.DTOs
{
    public class MessageDto
    {
        public Guid id { get; set; }
        public Guid userId { get; set; }
        public string userName { get; set; }
        public MessageType type { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }
    }
}
