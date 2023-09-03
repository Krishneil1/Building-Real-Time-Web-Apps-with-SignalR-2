using Microsoft.AspNetCore.SignalR;

namespace SignalRExample.Hubs
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.SendAsync("broadcastMessage", "System", $"{Context.ConnectionId} joined the conversation", DateTime.Now);
            return base.OnConnectedAsync();
        }
        public async Task SendMessage(string user, string message)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}

