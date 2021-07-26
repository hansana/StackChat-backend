using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;
using StackChatAPI.Application.Interfaces.Services;
using StackChatAPI.Domain.DTOs;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace StackChatAPI.Controllers
{
    [ApiVersion("1.0")]
    public class LoginController : ApiController
    {
        private readonly ILoginService _loginService;

        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<StackHub>();

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [System.Web.Http.HttpPost]
        public async Task<IActionResult> LoginUser(UserDto user)
        {
            var response = await _loginService.RegisterUser(user);
            hubContext.Clients.All.userLogin(user.userName + " Logged in!");

            return new OkObjectResult(response);
        }
    }
}
