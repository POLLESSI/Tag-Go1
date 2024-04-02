using Tag_Go.API.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace Tag_Go.API.Hubs
{
    public class BonusHub : Hub
    {
        public async Task NotifyNewBonus()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("receivebonusupdate");
            }
        }
        public async Task RefreshBonus()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("notifynewbonus");
            }
        }
        public async Task submit()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("bonus");
        }
        public async Task GetBonus()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("bonus");
        }
    }
}
