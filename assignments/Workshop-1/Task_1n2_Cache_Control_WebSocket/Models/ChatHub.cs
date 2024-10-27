using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Workshop_1.Models
{
    public sealed class ChatHub : Hub
    {
        //public override async Task OnConnectedAsync()
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} has joined");
        //}
        public async Task SendPublicMessage(string sender, string message)
        {
            await Clients.All.SendAsync("ReceivePublicMessage", sender, message);
        }

        [Authorize]
        public async Task SendMessageToPrivate(string user, string message)
        {
            await Clients.User(user).SendAsync("ReceivePrivateMessage", message);
        }

    }
}
