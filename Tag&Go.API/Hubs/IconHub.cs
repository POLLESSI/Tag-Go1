using Tag_Go.API.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace Tag_Go.API.Hubs
{
    public class IconHub : Hub
    {
        public async Task NotifyNewIcon()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("receiveiconupdate");
            }
        }
        public async Task RefreshIcon()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("notifynewicon");
            }
        }
        public async Task submit()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("icon");
        }
        public async Task GetIcon()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("icon");
        }
    }
}
