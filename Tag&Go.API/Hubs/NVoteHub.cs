using Tag_Go.API.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace Tag_Go.API.Hubs
{
    public class NVoteHub : Hub
    {
        public async Task RefreshVote()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("notifynewvote");
            }
        }
        //public async Task submit()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("vote");
        //}
        //public async Task GetVote()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("vote");
        //}
    }
}
