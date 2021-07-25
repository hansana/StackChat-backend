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
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [System.Web.Http.HttpGet]
        public async Task<IActionResult> SearchUsers(string searchString)
        {
            return new OkObjectResult(await _userService.GetUsersByNameOrEmail(searchString));
        }

        [System.Web.Http.HttpPut]
        public async Task<IActionResult> UpdateConnectionId(Guid id, UserConnectionId connection)
        {
            await _userService.UpdateUserConnectionId(id, connection.ConnectionId);
            return new OkResult();
        }
    }
}
