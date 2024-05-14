using Tag_Go.API.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace Tag_Go.API.Hubs
{
    public class ActivityHub : Hub
    {
        //public async Task NotifyNewActivity()
        //{
        //    if (Clients is not null)
        //    {
        //        await Clients.All.SendAsync("receiveactivityupdate");
        //    }
        //}
        public async Task RefreshActivity()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("notifynewactivity");
            }
        }
        //public async Task submit()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("activity");
        //}
        //public async Task GetActivity()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("activity");
        //}
    }
}
