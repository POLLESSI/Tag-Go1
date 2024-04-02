using Tag_Go.API.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace Tag_Go.API.Hubs
{
    public class PersonHub : Hub
    {
        public async Task NotifyNewPerson()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("receivepersonupdate");
            }
        }
        public async Task RefreshPerson()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("notifynewperson");
            }
        }
        public async Task submit()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("person");
        }
        public async Task GetPerson()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("person");
        }
    }
}
