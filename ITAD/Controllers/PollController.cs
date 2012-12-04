using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ITAD.Controllers
{
    public class PollController : ApiController
    {
        private readonly PollService _pollService = new PollService();

        public PollViewModel Get()
        {
            return _pollService.GetViewModel();
        }

        public IList<Vote> Post(Vote vote)
        {
            _pollService.Vote(vote);
            // foreach(var item in Votes){
            //  if (item.Answer == vote.Answer)
            //      item.Count++;
            //}
            return _pollService.GetVotes();
        }
    }

    public class PollViewModel
    {
        public string Question { get; set; }
        public IList<Vote> Votes { get; set; }
        public List<string> Answers { get; set; }
    }

    public class Vote
    {
        public string Answer { get; set; }
        public int Count { get; set; }
    }
}
