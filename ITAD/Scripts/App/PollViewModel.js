PollViewModel = function () {
    var self = this;

    self.Question = ko.observable();
    self.Answers = ko.observableArray();
    self.Votes = ko.observableArray();
    // mało istotne :P dziala!
    self.Percentage = ko.computed(function () {
        if (self.Votes().length === 0)
            return 50;
        var sum = self.Votes()[0].Count() + self.Votes()[1].Count();
        if (sum === 0)
            return 50;
        return parseInt(self.Votes()[0].Count() * 100 / (sum), 10);
    });

    self.Answer = ko.observable();
    self.vote = function () {
        $.connection.pollHub.server.vote(self.Answer());
//        DAL.vote(self.Answer()).done(function(votes) {
//            self.updateVotes(votes);
//        });
    };
    self.updateVotes = function(votes) {
        self.Votes($.map(votes, function(vote) { return new Vote(vote); }))
    };
};

Vote = function (vote) {
    var self = this;

    self.Answer = vote.Answer;
    self.Count = ko.observable(vote.Count);
};