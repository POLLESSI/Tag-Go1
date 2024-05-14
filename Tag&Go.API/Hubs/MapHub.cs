using Tag_Go.API.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace Tag_Go.API.Hubs
{
    public class MapHub : Hub
    {
        //public async Task NotifyNewMap()
        //{
        //    if (Clients is not null)
        //    {
        //        await Clients.All.SendAsync("receivemapupdate");
        //    }
        //}
        public async Task RefreshMap()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("notifynewmap");
            }
        }
        //public async Task submit()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("map");
        //}
        //public async Task GetMap()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("map");
        //}
    }
}
