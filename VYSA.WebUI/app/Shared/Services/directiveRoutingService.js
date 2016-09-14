(function () {
    "use strict";

    angular
        .module("vysaApp")
        .factory('directiveRoutingService', function () {
            return {

                getState: function (type) {
                    var state;
                    switch (type) {
                        case 'announcement':
                            state = 'websitemaintenance.announcements.addedit';
                            break;
                        case 'board':
                            state = 'websitemaintenance.boardmembers.addedit';
                            break;
                        case 'event':
                            state = 'clubmanagement.seasonmanagement.seasons.events.addedit';
                            break;
                        case 'player':
                            state = 'clubmanagement.players.addedit';
                            break;
                        case 'season':
                            state = 'clubmanagement.seasonmanagement.seasons.setup';
                            break;
                        case 'team':
                            state = 'clubmanagement.seasonmanagement.seasons.teams.setup';
                            break;
                    }
                    return state;
                }                
            }
        });
}());