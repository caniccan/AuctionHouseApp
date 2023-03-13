using Microsoft.AspNetCore.SignalR;

namespace AuctionHouse.Sourcing.Hubs
{
    public class AuctionHub :Hub
    {
        public async Task AddToGroupAsync(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendBidAsync(string groupName, string user, string bid)
        {
            await Clients.All.SendAsync("Bids",user,bid);
        }
    }
}
