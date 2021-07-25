using Microsoft.AspNetCore.Mvc;
using StackChatAPI.Application.Interfaces.Services;
using StackChatAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace StackChatAPI.Controllers
{
    public class MessagesController : ApiController
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [System.Web.Http.HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            return new OkObjectResult(await _messageService.GetAllMessages());
        }

        public async Task<IActionResult> PostMessage(MessageDto message)
        {
            return new OkObjectResult(await _messageService.SaveMessage(message));
        }
    }
}
