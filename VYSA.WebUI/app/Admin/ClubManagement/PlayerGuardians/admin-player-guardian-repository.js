(function () {
    "use strict";

    angular.module("vysaApp").factory('AdminPlayerGuardianRepository', function ($resource, config) {
        return $resource(config.apiServerUri + 'Admin/PlayerGuardians/:id', { id: '@id' }, {
            post: { method: 'POST' },
            update: { method: 'PUT' },
            delete: { method: 'DELETE' }
        });
    });
}());