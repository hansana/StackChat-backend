using Microsoft.AspNetCore.Mvc;
using StackChatAPI.Application.Interfaces.Services;
using StackChatAPI.Domain.DTOs;
using System.Threading.Tasks;
using System.Web.Http;

namespace StackChatAPI.Controllers
{
    [ApiVersion("1.0")]
    public class LoginController : ApiController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [System.Web.Http.HttpPost]
        public async Task<IActionResult> LoginUser(UserDto user)
        {
            return new OkObjectResult(await _loginService.RegisterUser(user));
        }
    }
}
