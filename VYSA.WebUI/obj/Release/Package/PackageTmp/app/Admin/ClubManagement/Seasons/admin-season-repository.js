(function () {
    "use strict";

    angular.module("admin").factory('AdminSeasonRepository', function ($resource, config) {
        return $resource(config.apiServerUri + '/Admin/Seasons/:id', { id: '@id' }, {
            get: { method: 'GET' },
            query: { method: 'GET', isArray: true },
            post: { method: 'POST' },
            update: { method: 'PUT' },
            delete: { method: 'DELETE' }
        });
    });
}());