DAL = (function() {
    var ajaxCall = function(url, type, data) {
        return $.ajax({
            url: url,
            type: type,
            dataType: 'json',
            contentType: 'application/json',
            data: ko.toJSON(data)
        });
    };
    return {
        getData : function() {
            return ajaxCall("/api/poll", "GET");
        },
        vote : function(answer) {
            return ajaxCall("/api/poll", "POST", { answer: answer });
        }
    };
})();