using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackChatAPI.Domain.DataModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? ConnectionId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }
    }
}