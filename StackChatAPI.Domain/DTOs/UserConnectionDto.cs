﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackChatAPI.Domain.DTOs
{
    public class UserConnectionDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ToUserId { get; set; }
        public string LastMessage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}