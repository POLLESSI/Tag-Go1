using Tag_Go.API.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace Tag_Go.API.Hubs
{
    public class NUserHub : Hub
    {
        //public async Task NotifyNewNUser()
        //{
        //    if (Clients is not null)
        //    {
        //        await Clients.All.SendAsync("receivenuserupdate");
        //    }
        //}
        public async Task RefreshNUser()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("notifynewnuser");
            }
        }
        //public async Task submit()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("nuser");
        //}
        //public async Task getNUser()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("nuser");
        //}
    }
}
