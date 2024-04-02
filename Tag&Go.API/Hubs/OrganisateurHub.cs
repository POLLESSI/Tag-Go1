using Tag_Go.API.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace Tag_Go.API.Hubs
{
    public class OrganisateurHub : Hub
    {
        public async Task NotifyNewOrganisateur()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("receiveorganisateurupdate");
            }
        }
        public async Task RefreshOrganisateur()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("notifyneworganisateur");
            }
        }
        public async Task submit()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("organisateur");
        }
        public async Task GetOrganisateur()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("organisateur");
        }
    }
}
