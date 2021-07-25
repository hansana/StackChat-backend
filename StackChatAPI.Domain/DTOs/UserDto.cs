using System;

namespace StackChatAPI.Domain.DTOs
{
    public class UserDto
    {
        public Guid id { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Guid? connectionId { get; set; }
        public DateTime createdAt { get; set; }
    }
}
