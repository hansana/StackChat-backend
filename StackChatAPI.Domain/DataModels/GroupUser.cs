using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackChatAPI.Domain.DataModels
{
    public class GroupUser
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }
    }
}