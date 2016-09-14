(function () {
    "use strict";

    angular.module("vysaApp").value('config', {
        apiServerUri: 'http://localhost:52310/' //localURL
        //apiServerUri: 'https://www.holmenvysa.com/webapi/' //production
    });
}());