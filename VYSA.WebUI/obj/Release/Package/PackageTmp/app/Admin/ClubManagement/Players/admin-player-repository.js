﻿(function () {
    "use strict";

    angular.module("admin").factory('AdminPlayerRepository',
        function ($resource, config) {

            return {
                players: $resource(config.apiServerUri + 'Admin/Players/:id', { id: '@id' }, {
                    get: { method: 'GET' },
                    //query: { method: 'GET', isArray: true },
                    post: { method: 'POST' },
                    update: { method: 'PUT' },
                    delete: { method: 'DELETE' }
                }),
                filter: $resource(config.apiServerUri + 'Admin/Players/filter/', {
                    pageNum: '@pageNum',
                    numRecs: '@numRecs',
                    getCount: '@getCount',
                }, {
                    post: { method: 'POST' },
                }),
                rosterAutoComplete: $resource(config.apiServerUri + 'Admin/Players/AutoComplete/Roster', {
                    lookupId: '@lookupId',
                    searchTerm: '@searchTerm'                    
                }, {
                    post: { method: 'POST' }
                }),
                
            }

        });

}());