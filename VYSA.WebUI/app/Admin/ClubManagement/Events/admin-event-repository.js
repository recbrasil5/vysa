(function () {
    "use strict";

    angular.module("vysaApp").factory('AdminEventRepository', function ($resource, config) {

        return {
            events: $resource(config.apiServerUri + 'Admin/Events/:id', { id: '@id' }, {
                get: { method: 'GET' },
                query: { method: 'GET', isArray: true },
                post: { method: 'POST' },
                update: { method: 'PUT' },
                delete: { method: 'DELETE' }
            }),

            eventSimpleListViewDtos: $resource(config.apiServerUri + 'Admin/Events/GetEventsBySeasonId/:seasonId', {
                seasonId: '@seasonId'
            }, {
                //get: { method: 'GET' },
                query: { method: 'GET', isArray: true },
                //post: { method: 'POST' },
                //update: { method: 'PUT' }

            })
        }

    });
}());