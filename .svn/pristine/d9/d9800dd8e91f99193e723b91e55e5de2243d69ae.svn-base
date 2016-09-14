(function () {
    "use strict";

    angular.module("vysaApp").factory('announcementRepository', function ($resource, config) {
        return $resource(config.apiServerUri + 'Announcements/:id', { id: '@id' }, {
            get: { method: 'GET' },
            query: { method: 'GET', isArray: true },
            post: { method: 'POST' },
            update: { method: 'PUT' }
        });
    });
}());