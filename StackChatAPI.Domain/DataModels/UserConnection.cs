using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackChatAPI.Domain.DataModels
{
    public class UserConnection
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ToUserId { get; set; }
        public string LastMessage { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime UpdatedAt { get; set; }
    }
}
