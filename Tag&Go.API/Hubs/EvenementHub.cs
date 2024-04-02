using Tag_Go.API.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace Tag_Go.API.Hubs
{
    public class EvenementHub : Hub
    {
        public async Task NotifyNewEvenementUpdate()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("receiveevenement");
            }
        }
        public async Task RefreshEvenement()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("notifynewevenement");
            }
        }
        public async Task submit()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("evenement");
        }
        public async Task GetEvenement()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("evenement");
        }
    }
}
