using Microsoft.AspNetCore.SignalR;

namespace MiPrimeraApi.Hubs
{
    public class ChatHub : Hub
    {
        public async Task FromClient(string user, string message)
        {
            await Clients.All.SendAsync("RecieveMessage", user, message);
        }
    }
}
