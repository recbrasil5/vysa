(function () {
    "use strict";

    angular.module("vysaApp").factory('ContactUsRepository', function ($resource, config) {
        return $resource(config.apiServerUri + 'ContactUs/:id', { id: '@id' }, {
            get: { method: 'GET' },
            query: { method: 'GET', isArray: true },
            post: { method: 'POST' },
            update: { method: 'PUT' },
            delete: { method: 'DELETE' }
        });
    });
}());