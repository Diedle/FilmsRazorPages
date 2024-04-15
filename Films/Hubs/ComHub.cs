using Microsoft.AspNetCore.SignalR;

namespace Films
{
    public class ComHub : Hub
    {
        public async Task Send(string username, string message)
        {
            await Clients.All.SendAsync("Receive", username, message);
        }
    }
}