(function () {
    "use strict";

    angular.module("vysaApp").factory('AdminTeamRepository', function ($resource, config) {
        return $resource(config.apiServerUri + 'Admin/Teams/:id', { id: '@id' }, {
            get: { method: 'GET' },
            query: { method: 'GET', isArray: true },
            post: { method: 'POST' },
            update: { method: 'PUT' },
            delete: { method: 'DELETE' }
        });
    });
}());