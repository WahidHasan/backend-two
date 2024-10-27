using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Workshop_1.Models;

namespace Workshop_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public MessageController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("public")]
        public async Task<IActionResult> SendPublicMessage([FromBody] MessageRequest request)
        {
            await _hubContext.Clients.All.SendAsync("ReceivePublicMessage", request.UserName, request.Message);
            return Ok(new {Message = "Message sent to public channel"});
        }

        [HttpPost("private")]
        [Authorize]
        public async Task<IActionResult> SendPrivateMessage([FromBody] PrivateMessageRequest request)
        {
            await _hubContext.Clients.User(request.User).SendAsync("ReceivePrivateMessage", request.Message);
            return Ok();
        }
    }

    public class MessageRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }

    public class PrivateMessageRequest
    {
        public string User { get; set; }
        public string Message { get; set; }
    }
}
