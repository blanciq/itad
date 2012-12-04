using System.Collections.Generic;
using System.Linq;

namespace ITAD.Controllers
{
    public class PollService
    {
        private static readonly IList<Vote> Votes =
            new List<Vote>
                {
                    new Vote {Answer = "PG"},
                    new Vote {Answer = "UG"}
                };

        public IList<Vote> GetVotes()
        {
            return Votes;
        }

        public void Vote(Vote vote)
        {
            var single = Votes.SingleOrDefault(x => x.Answer == vote.Answer);
            if (single != null)
                single.Count++;
        }

        public PollViewModel GetViewModel()
        {
            return new PollViewModel
                {
                    Question = "Która uczelnia jest NAJlepsza?",
                    Votes = Votes,
                    Answers = Votes.Select(x => x.Answer).ToList()
                };
        }
    }
}