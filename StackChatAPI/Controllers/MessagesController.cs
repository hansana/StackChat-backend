using Microsoft.AspNetCore.Mvc;
using StackChatAPI.Application.Interfaces.Services;
using StackChatAPI.Application.Parameters;
using StackChatAPI.Domain.DTOs;
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
        public async Task<IActionResult> GetAllMessages([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            return new OkObjectResult(await _messageService.GetAllMessages(pageNumber, pageSize));
        }

        public async Task<IActionResult> PostMessage(MessageDto message)
        {
            return new OkObjectResult(await _messageService.SaveMessage(message));
        }
    }
}
