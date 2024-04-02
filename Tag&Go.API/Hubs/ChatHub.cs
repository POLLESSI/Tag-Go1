using Tag_Go.API.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace Tag_Go.API.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("receivemessage", message);
        }
        public async Task JoinGroup(string groupName, string pseudo)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await SendToGroup(new Message
            {
                Author = "System",
                NewMessage = "A new user has logged in" + pseudo,
                //Evenement_Id = Message.Evenement_Id,
            }, groupName);
        }
        public async Task SendToGroup(Message message, string groupName)
        {
            await Clients.Group(groupName).SendAsync("messagefromgroup", message);
        }
        public async Task RefreshChat()
        {
            if (Clients is not null)
            {
                await Clients.All.SendAsync("notifynewchat");
            }
        }
        public async Task submit()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("chat");
        }
        public async Task GetChat()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("chat");
        }
    }
}
