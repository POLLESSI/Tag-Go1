using Tag_Go.API.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace Tag_Go.API.Hubs
{
    public class MediaItemHub : Hub
    {
        //public async Task NotifyNewMediaItem()
        //{
        //    if (Clients is not null)
        //    {
        //        await Clients.All.SendAsync("receivemediaitemupdate");
        //    }
        //}
        public async Task RefreshMediaItem()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("notifynewmediaitem");
            }
        }
        //public async Task submit()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("mediaitem");
        //}
        //public async Task GetMediaItem()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("mediaitem");
        //}
    }
}
