using Microsoft.AspNet.SignalR.Hubs;

namespace ITAD.Controllers
{
    public class PollHub : Hub
    {
        private readonly PollService _pollService = new PollService();

        public void Vote(string answer)
        {
            _pollService.Vote(new Vote {Answer = answer});

            Clients.All.UpdateVotes(_pollService.GetVotes())    ;
        }
    }
}