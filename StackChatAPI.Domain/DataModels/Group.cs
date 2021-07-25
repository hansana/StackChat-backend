using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackChatAPI.Domain.DataModels
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid GroupOwner { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }
    }
}