(function () {
    "use strict";

    angular.module("vysaApp").factory('AdminDivisionRepository', function ($resource, config) {
        return $resource(config.apiServerUri + 'Admin/Divisions/:id', { id: '@id' }, {
            get: { method: 'GET' },
            query: { method: 'GET', isArray: true },
            //post: { method: 'POST' },
            //update: { method: 'PUT' },
            //delete: { method: 'DELETE' }
        });
    });
}());