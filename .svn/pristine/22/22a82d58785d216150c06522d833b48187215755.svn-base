(function () {
    "use strict";

    angular.module("admin").factory('AdminBoardMemberRepository', function ($resource, config) {
        return $resource(config.apiServerUri + 'Admin/Board/:id', { id: '@id' }, {
            get: { method: 'GET' },
            query: { method: 'GET', isArray: true },
            post: { method: 'POST' },
            update: { method: 'PUT' },
            delete: { method: 'DELETE' }
        });
    });

}());