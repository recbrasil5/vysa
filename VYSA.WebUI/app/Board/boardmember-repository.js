(function () {
    "use strict";

    angular.module("vysaApp").factory('boardMemberRepository', function ($resource, config) {
        return $resource(config.apiServerUri + 'Board/:id', { id: '@id' }, {
            get: { method: 'GET' },
            query: { method: 'GET', isArray: true },
            post: { method: 'POST' },
            update: { method: 'PUT' }
        });
    });

}());